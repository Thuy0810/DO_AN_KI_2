namespace DO_AN_KI_2
{
    partial class QRPay
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
            this.cboNH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.abc = new System.Windows.Forms.Label();
            this.AddButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.imgPay = new System.Windows.Forms.PictureBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.moneyPay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPay)).BeginInit();
            this.SuspendLayout();
            // 
            // cboNH
            // 
            this.cboNH.BackColor = System.Drawing.Color.Transparent;
            this.cboNH.BorderRadius = 5;
            this.cboNH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNH.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNH.ForeColor = System.Drawing.Color.Black;
            this.cboNH.ItemHeight = 20;
            this.cboNH.Items.AddRange(new object[] {
            "Vietcombank",
            "MBbank"});
            this.cboNH.Location = new System.Drawing.Point(89, 102);
            this.cboNH.Name = "cboNH";
            this.cboNH.Size = new System.Drawing.Size(153, 26);
            this.cboNH.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "TỔNG TIỀN :";
            // 
            // abc
            // 
            this.abc.AutoSize = true;
            this.abc.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abc.Location = new System.Drawing.Point(8, 110);
            this.abc.Name = "abc";
            this.abc.Size = new System.Drawing.Size(69, 12);
            this.abc.TabIndex = 30;
            this.abc.Text = "NGÂN HÀNG :";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.BorderRadius = 5;
            this.AddButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddButton.FillColor = System.Drawing.Color.RoyalBlue;
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Location = new System.Drawing.Point(108, 226);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(92, 30);
            this.AddButton.TabIndex = 36;
            this.AddButton.Text = "Tạo mã QR";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(270, 398);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(70, 29);
            this.guna2Button1.TabIndex = 37;
            this.guna2Button1.Text = "Đóng";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // imgPay
            // 
            this.imgPay.Image = global::DO_AN_KI_2.Properties.Resources.Qr_Code;
            this.imgPay.Location = new System.Drawing.Point(270, 12);
            this.imgPay.Name = "imgPay";
            this.imgPay.Size = new System.Drawing.Size(302, 378);
            this.imgPay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPay.TabIndex = 0;
            this.imgPay.TabStop = false;
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(401, 398);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(171, 30);
            this.guna2Button2.TabIndex = 38;
            this.guna2Button2.Text = "Thanh toán thành công";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // moneyPay
            // 
            this.moneyPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneyPay.Location = new System.Drawing.Point(89, 161);
            this.moneyPay.Name = "moneyPay";
            this.moneyPay.Size = new System.Drawing.Size(153, 23);
            this.moneyPay.TabIndex = 39;
            this.moneyPay.Text = "10000";
            this.moneyPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QRPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 439);
            this.Controls.Add(this.moneyPay);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.cboNH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.abc);
            this.Controls.Add(this.imgPay);
            this.Name = "QRPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QRPay";
            this.Load += new System.EventHandler(this.QRPay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgPay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgPay;
        private Guna.UI2.WinForms.Guna2ComboBox cboNH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label abc;
        private Guna.UI2.WinForms.Guna2Button AddButton;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Label moneyPay;
    }
}