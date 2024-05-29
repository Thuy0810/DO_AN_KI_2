namespace DO_AN_KI_2
{
    partial class QR_Bank
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
            this.AddButton = new Guna.UI2.WinForms.Guna2Button();
            this.cboPay = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateOrder = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
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
            this.AddButton.Location = new System.Drawing.Point(56, 288);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(107, 30);
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "Tạo mã QR";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cboPay
            // 
            this.cboPay.BackColor = System.Drawing.Color.Transparent;
            this.cboPay.BorderRadius = 5;
            this.cboPay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPay.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPay.ForeColor = System.Drawing.Color.Black;
            this.cboPay.ItemHeight = 20;
            this.cboPay.Location = new System.Drawing.Point(230, 89);
            this.cboPay.Name = "cboPay";
            this.cboPay.Size = new System.Drawing.Size(140, 26);
            this.cboPay.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "PHƯƠNG THỨC THANH TOÁN :";
            // 
            // dateOrder
            // 
            this.dateOrder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dateOrder.BorderRadius = 5;
            this.dateOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dateOrder.DefaultText = "";
            this.dateOrder.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.dateOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.dateOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.dateOrder.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.dateOrder.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dateOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateOrder.ForeColor = System.Drawing.Color.Black;
            this.dateOrder.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dateOrder.Location = new System.Drawing.Point(213, 34);
            this.dateOrder.Name = "dateOrder";
            this.dateOrder.PasswordChar = '\0';
            this.dateOrder.PlaceholderText = "";
            this.dateOrder.ReadOnly = true;
            this.dateOrder.SelectedText = "";
            this.dateOrder.Size = new System.Drawing.Size(198, 29);
            this.dateOrder.TabIndex = 30;
            // 
            // QR_Bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 371);
            this.Controls.Add(this.cboPay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateOrder);
            this.Controls.Add(this.AddButton);
            this.Name = "QR_Bank";
            this.Text = "QR_Bank";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button AddButton;
        private Guna.UI2.WinForms.Guna2ComboBox cboPay;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox dateOrder;
    }
}