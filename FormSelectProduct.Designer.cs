namespace DO_AN_KI_2
{
    partial class FormSelectProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GnDtP = new Guna.UI2.WinForms.Guna2DataGridView();
            this.saveButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.quantityProduct = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.priceProduct = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.IDProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAREHOUSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GnDtP)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // GnDtP
            // 
            this.GnDtP.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.GnDtP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.GnDtP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GnDtP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GnDtP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GnDtP.ColumnHeadersHeight = 40;
            this.GnDtP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GnDtP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.quantity,
            this.OPrice,
            this.price,
            this.categoryPP,
            this.abc,
            this.status,
            this.WAREHOUSE});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GnDtP.DefaultCellStyle = dataGridViewCellStyle8;
            this.GnDtP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GnDtP.Location = new System.Drawing.Point(2, 78);
            this.GnDtP.Name = "GnDtP";
            this.GnDtP.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GnDtP.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.GnDtP.RowHeadersVisible = false;
            this.GnDtP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GnDtP.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.GnDtP.RowTemplate.Height = 35;
            this.GnDtP.Size = new System.Drawing.Size(1154, 462);
            this.GnDtP.TabIndex = 5;
            this.GnDtP.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GnDtP.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GnDtP.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GnDtP.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GnDtP.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GnDtP.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GnDtP.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GnDtP.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GnDtP.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GnDtP.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GnDtP.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GnDtP.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GnDtP.ThemeStyle.HeaderStyle.Height = 40;
            this.GnDtP.ThemeStyle.ReadOnly = true;
            this.GnDtP.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GnDtP.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GnDtP.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GnDtP.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GnDtP.ThemeStyle.RowsStyle.Height = 35;
            this.GnDtP.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GnDtP.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GnDtP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GnDtP_CellClick);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BorderRadius = 5;
            this.saveButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.saveButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.saveButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.saveButton.FillColor = System.Drawing.Color.RoyalBlue;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(1074, 546);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(70, 28);
            this.saveButton.TabIndex = 31;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "Chọn";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel1.Controls.Add(this.btnSearch);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1156, 37);
            this.guna2Panel1.TabIndex = 32;
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 5;
            this.btnSearch.CustomizableEdges.BottomLeft = false;
            this.btnSearch.CustomizableEdges.TopLeft = false;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::DO_AN_KI_2.Properties.Resources.SearchT;
            this.btnSearch.Location = new System.Drawing.Point(400, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 30);
            this.btnSearch.TabIndex = 11;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 5;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.CustomizableEdges.BottomRight = false;
            this.txtSearch.CustomizableEdges.TopRight = false;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(222, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(189, 30);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Image = global::DO_AN_KI_2.Properties.Resources.allProduct;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "TẤT CẢ SẢN PHẨM ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "Tên :";
            // 
            // nameProduct
            // 
            this.nameProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nameProduct.BorderRadius = 5;
            this.nameProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameProduct.DefaultText = "";
            this.nameProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nameProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nameProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nameProduct.ForeColor = System.Drawing.Color.Black;
            this.nameProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameProduct.Location = new System.Drawing.Point(156, 43);
            this.nameProduct.Name = "nameProduct";
            this.nameProduct.PasswordChar = '\0';
            this.nameProduct.PlaceholderText = "";
            this.nameProduct.ReadOnly = true;
            this.nameProduct.SelectedText = "";
            this.nameProduct.Size = new System.Drawing.Size(312, 29);
            this.nameProduct.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(789, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "SỐ LƯỢNG";
            // 
            // quantityProduct
            // 
            this.quantityProduct.BackColor = System.Drawing.Color.Transparent;
            this.quantityProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quantityProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quantityProduct.Location = new System.Drawing.Point(869, 43);
            this.quantityProduct.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.quantityProduct.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityProduct.Name = "quantityProduct";
            this.quantityProduct.Size = new System.Drawing.Size(76, 29);
            this.quantityProduct.TabIndex = 38;
            this.quantityProduct.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(503, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "GIÁ :";
            // 
            // priceProduct
            // 
            this.priceProduct.BackColor = System.Drawing.Color.Transparent;
            this.priceProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.priceProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.priceProduct.Location = new System.Drawing.Point(537, 43);
            this.priceProduct.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.priceProduct.Name = "priceProduct";
            this.priceProduct.Size = new System.Drawing.Size(229, 29);
            this.priceProduct.TabIndex = 39;
            // 
            // IDProduct
            // 
            this.IDProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.IDProduct.BorderRadius = 5;
            this.IDProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IDProduct.DefaultText = "";
            this.IDProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.IDProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.IDProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.IDProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.IDProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.IDProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IDProduct.ForeColor = System.Drawing.Color.Black;
            this.IDProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.IDProduct.Location = new System.Drawing.Point(44, 43);
            this.IDProduct.Name = "IDProduct";
            this.IDProduct.PasswordChar = '\0';
            this.IDProduct.PlaceholderText = "";
            this.IDProduct.ReadOnly = true;
            this.IDProduct.SelectedText = "";
            this.IDProduct.Size = new System.Drawing.Size(54, 29);
            this.IDProduct.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "ID :";
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "TÊN";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "SỐ LƯỢNG TRONG KHO";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // OPrice
            // 
            this.OPrice.HeaderText = "GIÁ GỐC";
            this.OPrice.Name = "OPrice";
            this.OPrice.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "GIÁ BÁN";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // categoryPP
            // 
            this.categoryPP.HeaderText = "PHÂN LOẠI";
            this.categoryPP.Name = "categoryPP";
            this.categoryPP.ReadOnly = true;
            // 
            // abc
            // 
            this.abc.HeaderText = "NHÀ CUNG CẤP";
            this.abc.Name = "abc";
            this.abc.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "TRẠNG THÁI";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // WAREHOUSE
            // 
            this.WAREHOUSE.HeaderText = "Column1";
            this.WAREHOUSE.Name = "WAREHOUSE";
            this.WAREHOUSE.ReadOnly = true;
            this.WAREHOUSE.Visible = false;
            // 
            // FormSelectProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 578);
            this.Controls.Add(this.IDProduct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.priceProduct);
            this.Controls.Add(this.quantityProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.GnDtP);
            this.Name = "FormSelectProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelectProduct";
            this.Load += new System.EventHandler(this.FormSelectProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GnDtP)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quantityProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView GnDtP;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox nameProduct;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2NumericUpDown quantityProduct;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2NumericUpDown priceProduct;
        private Guna.UI2.WinForms.Guna2TextBox IDProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn abc;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE;
    }
}