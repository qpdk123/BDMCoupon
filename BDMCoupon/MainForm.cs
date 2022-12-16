
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ChromeDriverUpdater;
using Keys = System.Windows.Forms.Keys;
using System.Windows.Forms.VisualStyles;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.DevTools.V100.Debugger;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;

namespace BDMCoupon
{
    public partial class MainForm : Form
    {
        int i = 0;
        ChromeDriverUpdater.ChromeDriverUpdater updater;
        ChromeDriverService chromeDriverService;
        ChromeDriver chromeDriver;
        ListBox lb_log;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; //WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0));
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount += 1;
            this.lb_log = new ListBox();
            this.lb_log.DrawMode = DrawMode.OwnerDrawFixed;
            this.lb_log.DrawItem += Lb_log_DrawItem;
            lb_log.Dock = DockStyle.Fill;
            lb_log.Margin = new Padding(0, 0, 0, 0);
            this.tableLayoutPanel1.Controls.Add(lb_log, 5, 0);
            this.tableLayoutPanel1.SetRowSpan(lb_log, 7);
            this.tableLayoutPanel1.ResumeLayout();

            LogManager.Ins.Load();
            LogManager.Ins.Push(new Log("Initialized"));

            updater = new ChromeDriverUpdater.ChromeDriverUpdater();
            updater.Update(@"chromedriver.exe");

            chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            chromeDriver = new ChromeDriver(chromeDriverService);
            chromeDriver.Navigate().GoToUrl("https://game.blackdesertm.com/coupon");

            this.btn_load.PerformClick();
        }
        public class ListBoxItemColorMessageSet
        {
            public ListBoxItemColorMessageSet(Color c, string m)
            {
                ItemColor = c;
                Message = m;
            }

            public Color ItemColor { get; set; }
            public string Message { get; set; }
        }

        private void Lb_log_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;    //아이템이 없는 경우 는 할 일이 없습니다.
            ListBoxItemColorMessageSet item = this.lb_log.Items[e.Index] as ListBoxItemColorMessageSet;

            //e.Graphics.DrawString(
            //    item.Message,
            //    this.lb_log.Font,
            //    new SolidBrush(item.ItemColor),
            //    0,
            //    e.Index * this.lb_log.ItemHeight
            //    );

            const TextFormatFlags formatFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, item.Message, e.Font, e.Bounds, item.ItemColor, formatFlags);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo file = new FileInfo(Path.Combine(Application.StartupPath, "Settings", "list.txt"));
                if (Directory.Exists(file.Directory.FullName) == false)
                {
                    Directory.CreateDirectory(file.Directory.FullName);
                    if (File.Exists(file.FullName) == false)
                    {
                        File.CreateText(file.FullName);
                    }
                }

                this.lb_nick.Items.Clear();
                this.lb_coupon.Items.Clear();
                this.txt_path.Text = file.FullName;

                string[] lines = System.IO.File.ReadAllLines(file.FullName);

                bool isnick = true;
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line) == true)
                    {
                        isnick = false;
                        continue;
                    }

                    if (isnick == true)
                    {
                        this.lb_nick.Items.Add(line.Trim());
                    }
                    else
                    {
                        this.lb_coupon.Items.Add(line.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Ins.Push(new Log(ex.ToString()));
                this.lbl_state.Text = "불러오기 오류";
            }
        }

        private async void btn_execute_Click(object sender, EventArgs e)
        {
            try
            {
                this.btn_execute.Enabled = false;

                for (int n = 0; n < this.lb_nick.Items.Count; ++n)
                {
                    string nickName = this.lb_nick.Items[n].ToString();
                    this.lb_nick.SelectedIndex = n;
                    for (int y = 0; y < this.lb_coupon.Items.Count; ++y)
                    {
                        string coupon = this.lb_coupon.Items[y].ToString();
                        LogManager.Ins.Push(new Log(string.Format("가문명 : {0} / 시작", nickName)));

                        this.lb_coupon.SelectedIndex = y;

                        //if (await Execute(nickName, coupon) == false)
                        //    break;
                        bool ret = false;
                        await Task.Run(() =>
                        {
                            ret = Execute(nickName, coupon).Result;
                        });

                        if (ret == false) break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Ins.Push(new Log(ex.ToString()));
                this.lbl_state.Text = "실행 오류";
            }
            finally
            {
                this.btn_execute.Enabled = true;
                this.PushLog("작업 완료");
            }
        }

        private async Task<bool> Execute(string nickName, string coupon)
        {
            try
            {
                //가문명 텍스트박스
                var txtNick = chromeDriver.FindElement(By.XPath("//*[@id=\"searchFrm\"]/div/input"));
                txtNick.Clear();
                txtNick.SendKeys(nickName);
                string strLog = string.Empty;

                //가문명 확인 버튼
                this.ClickWebButton("//*[@id=\"searchFrm\"]/div/button");
                strLog = "가문명 확인버튼 클릭";
                this.PushLog(strLog);

                //가문명 확인 멘트

                string logNick = this.GetTextFromWeb("/html/body/div[3]/div[1]/div/div[2]/div/span");
                strLog = string.Format("가문명 : {0} / {1}", nickName, logNick);
                if (logNick.Contains("캐릭터가 존재하지"))
                {
                    this.ClickWebButton("/html/body/div[3]/div[1]/div/div[3]/button");
                    this.PushLog(strLog, 2);
                    return false;
                }

                this.PushLog(strLog);

                //가문명 확인 완료 버튼
                this.ClickWebButton("html/body/div[3]/div[1]/div/div[3]/button");

                //쿠폰번호 텍스트 박스
                chromeDriver.FindElement(By.XPath("//*[@id=\"coupon01\"]")).Clear();
                chromeDriver.FindElement(By.XPath("//*[@id=\"coupon02\"]")).Clear();
                chromeDriver.FindElement(By.XPath("//*[@id=\"coupon03\"]")).Clear();
                chromeDriver.FindElement(By.XPath("//*[@id=\"coupon04\"]")).Clear();
                chromeDriver.FindElement(By.XPath("//*[@id=\"coupon01\"]")).SendKeys(coupon);

                //쿠폰 적용 버튼
                this.ClickWebButton("//*[@id=\"couponFrm\"]/div[3]/button");
                //strLog = string.Format("가문명 : {0} / 쿠폰번호 : {1}", nickName, coupon);
                //this.PushLog(strLog);

                // 쿠폰 확인 멘트
                string logCoupon = this.GetTextFromWeb("/html/body/div[3]/div[1]/div/div[2]/div/span");
                strLog = string.Format("가문명 : {0} / {1} / {2}", nickName, coupon, logCoupon);
                if (logCoupon.Contains("정상적인 쿠폰번호를") == true)
                {
                    this.ClickWebButton("/html/body/div[3]/div[1]/div/div[3]/button");
                    this.PushLog(strLog, 2);
                    return true; //닉네임이 틀린경우에만 false
                }

                //this.PushLog(strLog);

                //쿠폰 적용 확인 버튼
                this.ClickWebButton("/html/body/div[3]/div[1]/div/div[3]/button[2]");

                Thread.Sleep(100);
                //마무리 멘트 
                string logComplete = this.GetTextFromWeb("/html/body/div[3]/div[1]/div/div[2]/div/span");
                strLog = string.Format("가문명 : {0} / {1} / {2}", nickName, coupon, logComplete);
                if (logComplete.Contains("쿠폰이 정상적으로") == true)
                {
                    this.PushLog(strLog, 1);
                }
                else
                {
                    this.PushLog(strLog);
                }

                //마무리 멘트 버튼
                this.ClickWebButton("/html/body/div[3]/div[1]/div/div[3]/button");
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        private void PushLog(String text, int state = 0)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    text = text.Replace(Environment.NewLine, " ");
                    this.lbl_state.Text = text;
                    LogManager.Ins.Push(new Log(text));
                    switch (state)
                    {
                        case 0: //normal
                            this.lb_log.Items.Add(new ListBoxItemColorMessageSet(Color.Black, text));
                            break;
                        case 1: //success
                            this.lb_log.Items.Add(new ListBoxItemColorMessageSet(Color.Green, text));
                            break;
                        case 2: //fail
                            this.lb_log.Items.Add(new ListBoxItemColorMessageSet(Color.Red, text));
                            break;
                    }

                    this.lb_log.SelectedIndex = this.lb_log.Items.Count - 1;
                    this.lb_log.SelectedIndex = -1;
                }));
            }
            else
            {
                text = text.Replace(Environment.NewLine, " ");
                this.lbl_state.Text = text;
                LogManager.Ins.Push(new Log(text));
                switch (state)
                {
                    case 0: //normal
                        this.lb_log.Items.Add(new ListBoxItemColorMessageSet(Color.Black, text));
                        break;
                    case 1: //success
                        this.lb_log.Items.Add(new ListBoxItemColorMessageSet(Color.Green, text));
                        break;
                    case 2: //fail
                        this.lb_log.Items.Add(new ListBoxItemColorMessageSet(Color.Red, text));
                        break;
                }

                this.lb_log.SelectedIndex = this.lb_log.Items.Count - 1;
                this.lb_log.SelectedIndex = -1;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.chromeDriver.Quit();
        }

        private bool WaitForVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(this.chromeDriver, TimeSpan.FromSeconds(5));
            try
            {
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private string GetTextFromWeb(string xPath)
        {
            WebDriverWait wait = new WebDriverWait(this.chromeDriver, TimeSpan.FromSeconds(5));
            string ret = string.Empty;
            try
            {
                By by = By.XPath(xPath);
                if (this.WaitForVisible(by) == true)
                {
                    ret = chromeDriver.FindElement(by).Text;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return ret;
        }

        private void ClickWebButton(string xPath)
        {
            WebDriverWait wait = new WebDriverWait(this.chromeDriver, TimeSpan.FromSeconds(5));
            try
            {
                By by = By.XPath(xPath);
                if (this.WaitForVisible(by) == true)
                {
                    chromeDriver.FindElement(by).Click();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text.Equals("◀") == true)
            {
                this.tableLayoutPanel1.SuspendLayout();
                this.Width = 520;
                this.tableLayoutPanel1.ColumnStyles[this.tableLayoutPanel1.ColumnCount - 1].Width = 0;
                this.button1.Text = "▶";
                this.tableLayoutPanel1.ResumeLayout();

            }
            else
            {


                this.tableLayoutPanel1.SuspendLayout();
                this.Width = 1020;
                this.tableLayoutPanel1.ColumnStyles[this.tableLayoutPanel1.ColumnCount - 1].Width = 500;
                this.button1.Text = "◀";
                this.tableLayoutPanel1.ResumeLayout();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(Path.Combine(Application.StartupPath, "Settings", "list.txt"));
            if (Directory.Exists(file.Directory.FullName) == false)
            {
                Directory.CreateDirectory(file.Directory.FullName);
                if (File.Exists(file.FullName) == false)
                {
                    File.CreateText(file.FullName);
                }
            }

            Process.Start("notepad.exe", file.FullName);
        }
    }
}