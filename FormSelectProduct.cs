﻿using DO_AN_KI_2.service;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public enum modeFormAddProduct
    {
        importProduct, Order
    }
    public partial class FormSelectProduct : Form
    {

        DataServices DataServices = new DataServices();

        modeFormAddProduct mode;

        public ProductModelAdd productModel;

        int quantityInWareHouse = 0;

        string supplierID = "";

        int maxQuantity = 999999999;

        int monthsWarranty = 0;
        public FormSelectProduct(modeFormAddProduct mode, string supplierID = "")
        {
            InitializeComponent();
            GnDtP.Columns[0].Width = 40;
            this.mode = mode;
            this.supplierID = supplierID;
        }


        void fetchData()
        {

            string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, p.monthsWarranty,  c.name, c.categoryID, t.trademarkID, p.status, p.supplierID, p.weight, p.description, p.isPhysic, p.img , s.supplierName " +
              "FROM tblPRODUCT p " +
              "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
              "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
              $"INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID";

            if (mode == modeFormAddProduct.importProduct)
            {
                query += $" where s.supplierID = {supplierID}";
            }
            if (mode == modeFormAddProduct.Order)
            {
                query += $" where p.status = 1";
            }

            DataTable dataTable = (DataTable)DataServices.ShowObjectData(query);
            foreach (DataRow row in dataTable.Rows)
            {
                int id = Convert.ToInt32(row["ProductID"]);
                string productName = row["nameProduct"].ToString();
                int quantity = Convert.ToInt32(row["quantity"]);

                int originPrice = Convert.ToInt32(row["originPrice"]);
                int price = Convert.ToInt32(row["price"]);
                int noLimit = Convert.ToInt32(row["noLimit"]);
                string display = (noLimit == 1) ? "Không giới hạn " : quantity.ToString();
                string nameCategory = row["name"].ToString();
                int status = Convert.ToInt32(row["status"]);
                string dispStatus = (status == 1) ? "Hoạt động" : "Không hoạt động ";
                string nameSuplider = row["supplierName"].ToString();

                foreach (DataGridViewColumn column in GnDtP.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                GnDtP.Rows.Add(id, productName, display, originPrice, price, nameCategory, nameSuplider, dispStatus, quantity, (int)row["monthsWarranty"]);
            }

        }

        private void FormSelectProduct_Load(object sender, EventArgs e)
        {
            fetchData();
            if (mode == modeFormAddProduct.Order)
            {
                originPrice.Visible = false;
                status.Visible = false;
                priceProduct.Enabled = false;
            }
        }

        private void GnDtP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            quantityProduct.Value = 1;
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                IDProduct.Text = GnDtP.Rows[e.RowIndex].Cells[0].Value.ToString();
                nameProduct.Text = GnDtP.Rows[e.RowIndex].Cells[1].Value.ToString();
                quantityInWareHouse = Int32.Parse(GnDtP.Rows[e.RowIndex].Cells[8].Value.ToString());
                if (mode == modeFormAddProduct.importProduct)
                {
                    priceProduct.Value = Int32.Parse(GnDtP.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
                if (mode == modeFormAddProduct.Order)
                {
                    priceProduct.Value = Int32.Parse(GnDtP.Rows[e.RowIndex].Cells[4].Value.ToString());
                    if (GnDtP.Rows[e.RowIndex].Cells[2].Value.ToString().TrimEnd() != "Không giới hạn")
                    {
                        maxQuantity = quantityInWareHouse;
                    }
                    else
                    {
                        maxQuantity = 9999999;
                    }
                }
                monthsWarranty = Int32.Parse(GnDtP.Rows[e.RowIndex].Cells[9].Value.ToString());

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IDProduct.Text != string.Empty)
            {
                productModel = new ProductModelAdd(IDProduct.Text, nameProduct.Text, (int)quantityProduct.Value, (int)priceProduct.Value, quantityInWareHouse, monthsWarranty);
            }
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataServices.OpenDB();
                string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.name, c.categoryID, t.trademarkID, p.status, p.supplierID, p.weight, p.description, p.isPhysic, p.img , s.supplierName " +
              "FROM tblPRODUCT p " +
              "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
              "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
              "INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID where nameProduct like @nameProduct";
                if (mode == modeFormAddProduct.importProduct)
                {
                    query += $" and s.supplierID = {supplierID}";
                }
                if (mode == modeFormAddProduct.Order)
                {
                    query += $" and p.status = 1";
                }
                using (SqlCommand command = new SqlCommand(query, DataServices.connection))
                {
                    command.Parameters.AddWithValue("@nameProduct", "%" + txtSearch.Text.Trim('\'') + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Products");
                        DataTable dataTable = dataSet.Tables["Products"];
                        GnDtP.Rows.Clear();

                        foreach (DataRow row in dataTable.Rows)
                        {

                            int id = Convert.ToInt32(row["ProductID"]);
                            string productName = row["nameProduct"].ToString();
                            int quantity = Convert.ToInt32(row["quantity"]);
                            int originPrice = Convert.ToInt32(row["originPrice"]);
                            int price = Convert.ToInt32(row["price"]);
                            int noLimit = Convert.ToInt32(row["noLimit"]);
                            string display = (noLimit == 1) ? "Không giới hạn " : quantity.ToString();
                            string nameCategory = row["name"].ToString();
                            int status = Convert.ToInt32(row["status"]);
                            string dispStatus = (status == 1) ? "Hoạt động" : "Không hoạt động";
                            string nameSuplider = row["supplierName"].ToString();

                            foreach (DataGridViewColumn column in GnDtP.Columns)
                            {
                                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }

                            //Console.WriteLine($"Name: {productName}, Price: {price}");
                            GnDtP.Rows.Add(id, productName, display, originPrice, price, nameCategory, nameSuplider, dispStatus, quantity);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error +{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataServices.CloseDB();
        }

        private void quantityProduct_ValueChanged(object sender, EventArgs e)
        {
            if (quantityProduct.Value > maxQuantity)
            {
                message.showWarning("không chọn giá trị lớn hơn số lượng trong kho");
                quantityProduct.Value = maxQuantity;
            }
        }
    }
    public class ProductModelAdd
    {
        public string id { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int quantityInWareHouse { get; set; }
        public int monthsWarranty { get; set; }
        public ProductModelAdd(string id, string productName, int quantity, int price, int quantityInWareHouse, int monthsWarranty)
        {
            this.productName = productName;
            this.id = id;
            this.quantity = quantity;
            this.price = price;
            this.quantityInWareHouse = quantityInWareHouse;
            this.monthsWarranty = monthsWarranty;
        }
    }
}
