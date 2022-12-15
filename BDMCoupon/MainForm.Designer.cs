namespace BDMCoupon
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_coupon = new System.Windows.Forms.ListBox();
            this.lb_nick = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_state = new System.Windows.Forms.Label();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_execute = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lb_coupon, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lb_nick, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_state, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txt_path, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_load, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_execute, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 524);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lb_coupon
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lb_coupon, 2);
            this.lb_coupon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_coupon.FormattingEnabled = true;
            this.lb_coupon.ItemHeight = 15;
            this.lb_coupon.Location = new System.Drawing.Point(241, 45);
            this.lb_coupon.Margin = new System.Windows.Forms.Padding(0);
            this.lb_coupon.Name = "lb_coupon";
            this.tableLayoutPanel1.SetRowSpan(this.lb_coupon, 4);
            this.lb_coupon.Size = new System.Drawing.Size(239, 455);
            this.lb_coupon.TabIndex = 1;
            // 
            // lb_nick
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lb_nick, 2);
            this.lb_nick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_nick.FormattingEnabled = true;
            this.lb_nick.ItemHeight = 15;
            this.lb_nick.Location = new System.Drawing.Point(1, 45);
            this.lb_nick.Margin = new System.Windows.Forms.Padding(0);
            this.lb_nick.Name = "lb_nick";
            this.tableLayoutPanel1.SetRowSpan(this.lb_nick, 4);
            this.lb_nick.Size = new System.Drawing.Size(239, 455);
            this.lb_nick.TabIndex = 0;
            // 
            // label1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(1, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "가문명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(241, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "쿠폰번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_state
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_state, 3);
            this.lbl_state.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_state.Location = new System.Drawing.Point(1, 501);
            this.lbl_state.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(359, 22);
            this.lbl_state.TabIndex = 4;
            this.lbl_state.Text = "초기화...\r\n";
            this.lbl_state.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_path
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txt_path, 2);
            this.txt_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_path.Location = new System.Drawing.Point(1, 1);
            this.txt_path.Margin = new System.Windows.Forms.Padding(0);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(239, 23);
            this.txt_path.TabIndex = 5;
            // 
            // btn_load
            // 
            this.btn_load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_load.Location = new System.Drawing.Point(361, 1);
            this.btn_load.Margin = new System.Windows.Forms.Padding(0);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(119, 21);
            this.btn_load.TabIndex = 6;
            this.btn_load.Text = "다시불러오기";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_execute
            // 
            this.btn_execute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_execute.Location = new System.Drawing.Point(361, 501);
            this.btn_execute.Margin = new System.Windows.Forms.Padding(0);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(119, 22);
            this.btn_execute.TabIndex = 7;
            this.btn_execute.Text = "실행";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(481, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 7);
            this.button1.Size = new System.Drawing.Size(22, 522);
            this.button1.TabIndex = 8;
            this.button1.Text = "▶";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(241, 1);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 21);
            this.button2.TabIndex = 9;
            this.button2.Text = "설정파일열기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(504, 524);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "[ver 1.0] 검사모 강제 쿠폰 주입기 (made by 고승이)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label lbl_state;
        private TextBox txt_path;
        private Button btn_load;
        private Button btn_execute;
        private ListBox lb_coupon;
        private ListBox lb_nick;
        private Button button1;
        private Button button2;
    }
}