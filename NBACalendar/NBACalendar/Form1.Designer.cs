namespace NBACalendar
{
    partial class Calendar
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMonthInfo = new System.Windows.Forms.Panel();
            this.panelCalendarInfo = new System.Windows.Forms.Panel();
            this.panelDateInfo = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelMonthInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMonthInfo
            // 
            this.panelMonthInfo.BackColor = System.Drawing.SystemColors.Window;
            this.panelMonthInfo.BackgroundImage = global::NBACalendar.Properties.Resources.xhbjbj;
            this.panelMonthInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMonthInfo.Controls.Add(this.panelCalendarInfo);
            this.panelMonthInfo.Controls.Add(this.panelDateInfo);
            this.panelMonthInfo.Controls.Add(this.comboBox2);
            this.panelMonthInfo.Controls.Add(this.comboBox1);
            this.panelMonthInfo.Controls.Add(this.label2);
            this.panelMonthInfo.Controls.Add(this.label1);
            this.panelMonthInfo.Controls.Add(this.button1);
            this.panelMonthInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMonthInfo.Location = new System.Drawing.Point(0, 0);
            this.panelMonthInfo.Name = "panelMonthInfo";
            this.panelMonthInfo.Size = new System.Drawing.Size(749, 821);
            this.panelMonthInfo.TabIndex = 1;
            this.panelMonthInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonthInfo_Paint);
            this.panelMonthInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMonthInfo_MouseClick);
            // 
            // panelCalendarInfo
            // 
            this.panelCalendarInfo.BackgroundImage = global::NBACalendar.Properties.Resources.bgbg5;
            this.panelCalendarInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCalendarInfo.Location = new System.Drawing.Point(0, 442);
            this.panelCalendarInfo.Name = "panelCalendarInfo";
            this.panelCalendarInfo.Size = new System.Drawing.Size(750, 378);
            this.panelCalendarInfo.TabIndex = 6;
            this.panelCalendarInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCalendarInfo_Paint);
            // 
            // panelDateInfo
            // 
            this.panelDateInfo.AutoSize = true;
            this.panelDateInfo.BackColor = System.Drawing.Color.White;
            this.panelDateInfo.BackgroundImage = global::NBACalendar.Properties.Resources.nba3;
            this.panelDateInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDateInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDateInfo.Location = new System.Drawing.Point(571, 41);
            this.panelDateInfo.Name = "panelDateInfo";
            this.panelDateInfo.Size = new System.Drawing.Size(179, 395);
            this.panelDateInfo.TabIndex = 5;
            this.panelDateInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDateInfo_Paint);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(277, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(87, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Image = global::NBACalendar.Properties.Resources._7;
            this.label2.Location = new System.Drawing.Point(230, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "月份";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::NBACalendar.Properties.Resources._7;
            this.label1.Location = new System.Drawing.Point(40, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "年份";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.BackgroundImage = global::NBACalendar.Properties.Resources._7;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(422, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "跳转到今天";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 821);
            this.Controls.Add(this.panelMonthInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calendar";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NBA万年历";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMonthInfo.ResumeLayout(false);
            this.panelMonthInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMonthInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panelDateInfo;
        private System.Windows.Forms.Panel panelCalendarInfo;
        private System.Windows.Forms.Label label1;
    }
}

