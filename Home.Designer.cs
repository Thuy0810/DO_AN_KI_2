namespace DO_AN_KI_2
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.datepickerHome = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.hours = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.date = new Guna.UI2.WinForms.Guna2Panel();
            this.totalDate = new System.Windows.Forms.Label();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.totalImportMonth = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.month = new Guna.UI2.WinForms.Guna2Panel();
            this.totalMonth = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.impotMonth = new Guna.UI2.WinForms.Guna2Panel();
            this.totalImMonth = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.totalAllFull = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.date.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            this.month.SuspendLayout();
            this.impotMonth.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Khaki;
            this.guna2Panel1.Controls.Add(this.datepickerHome);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.hours);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(710, 34);
            this.guna2Panel1.TabIndex = 21;
            // 
            // datepickerHome
            // 
            this.datepickerHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datepickerHome.BackColor = System.Drawing.Color.Transparent;
            this.datepickerHome.Checked = true;
            this.datepickerHome.FillColor = System.Drawing.Color.Goldenrod;
            this.datepickerHome.FocusedColor = System.Drawing.Color.Transparent;
            this.datepickerHome.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datepickerHome.ForeColor = System.Drawing.SystemColors.Desktop;
            this.datepickerHome.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datepickerHome.Location = new System.Drawing.Point(579, 0);
            this.datepickerHome.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datepickerHome.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datepickerHome.Name = "datepickerHome";
            this.datepickerHome.Size = new System.Drawing.Size(131, 34);
            this.datepickerHome.TabIndex = 22;
            this.datepickerHome.Value = new System.DateTime(2024, 5, 19, 23, 57, 19, 339);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "XIN CHÀO: TÔ THỊ THỦY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hours
            // 
            this.hours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hours.BackColor = System.Drawing.Color.Transparent;
            this.hours.Font = new System.Drawing.Font("Leelawadee UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hours.Image = global::DO_AN_KI_2.Properties.Resources.Clock;
            this.hours.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hours.Location = new System.Drawing.Point(448, 0);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(140, 34);
            this.hours.TabIndex = 37;
            this.hours.Text = "20:25";
            this.hours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.date.BackColor = System.Drawing.Color.Transparent;
            this.date.BorderRadius = 10;
            this.date.Controls.Add(this.totalDate);
            this.date.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.date.CustomBorderThickness = new System.Windows.Forms.Padding(1);
            this.date.Location = new System.Drawing.Point(24, 32);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(407, 29);
            this.date.TabIndex = 29;
            // 
            // totalDate
            // 
            this.totalDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.totalDate.Location = new System.Drawing.Point(84, -4);
            this.totalDate.Name = "totalDate";
            this.totalDate.Size = new System.Drawing.Size(226, 33);
            this.totalDate.TabIndex = 0;
            this.totalDate.Text = "1 500 000 đồng";
            this.totalDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guna2ShadowPanel2.Controls.Add(this.guna2PictureBox1);
            this.guna2ShadowPanel2.Controls.Add(this.guna2GradientPanel2);
            this.guna2ShadowPanel2.Controls.Add(this.label5);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(-9, 32);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.ShadowDepth = 200;
            this.guna2ShadowPanel2.ShadowShift = 3;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(735, 419);
            this.guna2ShadowPanel2.TabIndex = 24;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox1.BorderRadius = 20;
            this.guna2PictureBox1.Image = global::DO_AN_KI_2.Properties.Resources.images__2_;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(503, 8);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(163, 119);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 5;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(34, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(436, 42);
            this.label5.TabIndex = 3;
            this.label5.Text = "Chào mừng bạn đến với hệ thống quản lý kho và bán hàng";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2GradientPanel2.BorderThickness = 2;
            this.guna2GradientPanel2.Controls.Add(this.label3);
            this.guna2GradientPanel2.Controls.Add(this.totalImportMonth);
            this.guna2GradientPanel2.Controls.Add(this.date);
            this.guna2GradientPanel2.Controls.Add(this.label);
            this.guna2GradientPanel2.Controls.Add(this.month);
            this.guna2GradientPanel2.Controls.Add(this.label4);
            this.guna2GradientPanel2.Controls.Add(this.impotMonth);
            this.guna2GradientPanel2.Controls.Add(this.total);
            this.guna2GradientPanel2.Controls.Add(this.guna2Panel5);
            this.guna2GradientPanel2.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2GradientPanel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(9, 131);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(710, 288);
            this.guna2GradientPanel2.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Image = global::DO_AN_KI_2.Properties.Resources.date2;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(21, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 33);
            this.label3.TabIndex = 25;
            this.label3.Text = "Doanh Thu Ngày 19 :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalImportMonth
            // 
            this.totalImportMonth.BackColor = System.Drawing.Color.Transparent;
            this.totalImportMonth.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalImportMonth.ForeColor = System.Drawing.Color.Red;
            this.totalImportMonth.Image = global::DO_AN_KI_2.Properties.Resources.Cash;
            this.totalImportMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.totalImportMonth.Location = new System.Drawing.Point(25, 68);
            this.totalImportMonth.Name = "totalImportMonth";
            this.totalImportMonth.Size = new System.Drawing.Size(192, 29);
            this.totalImportMonth.TabIndex = 26;
            this.totalImportMonth.Text = "Tiền Nhập Hàng Tháng 5 :";
            this.totalImportMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Red;
            this.label.Image = global::DO_AN_KI_2.Properties.Resources.date1;
            this.label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label.Location = new System.Drawing.Point(21, 122);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(150, 30);
            this.label.TabIndex = 27;
            this.label.Text = "Doanh Thu Tháng 5 :";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // month
            // 
            this.month.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.month.BackColor = System.Drawing.Color.Transparent;
            this.month.BorderRadius = 5;
            this.month.Controls.Add(this.totalMonth);
            this.month.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.month.CustomBorderThickness = new System.Windows.Forms.Padding(1);
            this.month.Location = new System.Drawing.Point(24, 143);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(407, 30);
            this.month.TabIndex = 31;
            // 
            // totalMonth
            // 
            this.totalMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.totalMonth.Location = new System.Drawing.Point(89, 1);
            this.totalMonth.Name = "totalMonth";
            this.totalMonth.Size = new System.Drawing.Size(249, 30);
            this.totalMonth.TabIndex = 2;
            this.totalMonth.Text = "1 500 000 đồng";
            this.totalMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Image = global::DO_AN_KI_2.Properties.Resources.Guarantee;
            this.label4.Location = new System.Drawing.Point(831, -8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 67);
            this.label4.TabIndex = 38;
            // 
            // impotMonth
            // 
            this.impotMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.impotMonth.BackColor = System.Drawing.Color.Transparent;
            this.impotMonth.BorderRadius = 5;
            this.impotMonth.Controls.Add(this.totalImMonth);
            this.impotMonth.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.impotMonth.CustomBorderThickness = new System.Windows.Forms.Padding(1);
            this.impotMonth.FillColor = System.Drawing.Color.Transparent;
            this.impotMonth.Location = new System.Drawing.Point(25, 87);
            this.impotMonth.Name = "impotMonth";
            this.impotMonth.Size = new System.Drawing.Size(406, 31);
            this.impotMonth.TabIndex = 30;
            // 
            // totalImMonth
            // 
            this.totalImMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalImMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalImMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalImMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.totalImMonth.Location = new System.Drawing.Point(87, 7);
            this.totalImMonth.Name = "totalImMonth";
            this.totalImMonth.Size = new System.Drawing.Size(254, 19);
            this.totalImMonth.TabIndex = 1;
            this.totalImMonth.Text = "1 500 000 đồng";
            this.totalImMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // total
            // 
            this.total.BackColor = System.Drawing.Color.Transparent;
            this.total.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.total.Image = global::DO_AN_KI_2.Properties.Resources.total;
            this.total.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.total.Location = new System.Drawing.Point(25, 177);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(173, 31);
            this.total.TabIndex = 28;
            this.total.Text = "TỔNG DOANH THU :";
            this.total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.BorderRadius = 5;
            this.guna2Panel5.Controls.Add(this.totalAllFull);
            this.guna2Panel5.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel5.CustomBorderThickness = new System.Windows.Forms.Padding(1);
            this.guna2Panel5.Location = new System.Drawing.Point(25, 195);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(406, 36);
            this.guna2Panel5.TabIndex = 31;
            // 
            // totalAllFull
            // 
            this.totalAllFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalAllFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAllFull.ForeColor = System.Drawing.Color.Red;
            this.totalAllFull.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.totalAllFull.Location = new System.Drawing.Point(87, 7);
            this.totalAllFull.Name = "totalAllFull";
            this.totalAllFull.Size = new System.Drawing.Size(226, 25);
            this.totalAllFull.TabIndex = 3;
            this.totalAllFull.Text = "1 500 000 đồng";
            this.totalAllFull.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 450);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load_1);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.date.ResumeLayout(false);
            this.guna2ShadowPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.month.ResumeLayout(false);
            this.impotMonth.ResumeLayout(false);
            this.guna2Panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker datepickerHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Panel date;
        private System.Windows.Forms.Label totalDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label totalImportMonth;
        private Guna.UI2.WinForms.Guna2Panel impotMonth;
        private System.Windows.Forms.Label totalImMonth;
        private Guna.UI2.WinForms.Guna2Panel month;
        private System.Windows.Forms.Label totalMonth;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label totalAllFull;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label hours;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
    }
}