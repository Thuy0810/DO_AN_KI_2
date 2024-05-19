using DO_AN_KI_2.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DO_AN_KI_2
{

    public partial class ImportDetail : Form
    {
        private ImportModel model;
        private bool modeNew = false;
        DataServices dbservice = new DataServices();
        int totalPriceNum = 0;

        public List<ProductModelAdd> listProductModel = new List<ProductModelAdd>();

        public ImportDetail(ImportModel importModel = null, bool modeNew = false)
        {
            InitializeComponent();
            model = importModel;
            this.modeNew = modeNew;
            if (modeNew)
            {
                label1.Text = "THÊM MỚI PHIẾU NHẬP";
            }
        }

        void showDataSupplier()
        {
            string query = @"select * from tblSUPPLIER ";

            supplier.DataSource = dbservice.ShowObjectData(query);
            supplier.ValueMember = "supplierID";
            supplier.DisplayMember = "supplierName";
        }

        private void ImportDetail_Load(object sender, EventArgs e)
        {

            showDataSupplier();

            dateImport.Text = DateTime.Now.ToString();

            if (!modeNew)
            {
                AddButton.Visible = false;
                saveButton.Visible = false;

                nameImport.Text = model.name;
                nameImport.ReadOnly = true;

                supplier.SelectedValue = model.suplider;

                totalPrice.Text = model.total;
                totalPrice.ReadOnly = true;

                description.Text = model.description;
                description.ReadOnly = true;

                dateImport.Text = model.dateImport;

                string query = $"select * from tblImportProductDetail as dt left join tblPRODUCT as pr on dt.ProductID = pr.ProductID where dt.ImportProductID='{model.id}';";

                DataGridView.DataSource = (DataTable)dbservice.ShowObjectData(query);
                DataGridView.AutoGenerateColumns = false;
                DataGridView.Columns.Clear();

                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.DataPropertyName = "ProductID";
                col1.HeaderText = "ID";
                DataGridView.Columns.Add(col1);

                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.DataPropertyName = "nameProduct";
                col2.HeaderText = "TÊN";
                DataGridView.Columns.Add(col2);

                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.DataPropertyName = "price";
                col3.HeaderText = "GIÁ (VND)";
                DataGridView.Columns.Add(col3);

                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.DataPropertyName = "quantity";
                col4.HeaderText = "SỐ LƯỢNG";
                DataGridView.Columns.Add(col4);
            }
        }

        private void addNewRecord()
        {
            if (modeNew)
            {
                DateTime today = DateTime.Now;
                Guid id = Guid.NewGuid();
                model = new ImportModel(id.ToString(), nameImport.Text, description.Text, totalPriceNum.ToString(), supplier.SelectedValue.ToString(), today.ToString());

                string queryImport = $"insert into tblImportProduct values ('{id}',@name,@description,{model.total},{model.suplider},'{today}');";
                dbservice.OpenDB();

                SqlCommand sqlCommand = new SqlCommand(queryImport, dbservice.connection);
                sqlCommand.Parameters.AddWithValue("@name", model.name);
                sqlCommand.Parameters.AddWithValue("@description", model.description);
                sqlCommand.ExecuteNonQuery();


                foreach (var item in listProductModel)
                {
                    string qr = $"insert into tblImportProductDetail values ('{id}',{item.id},{item.price},{item.quantity})";
                    dbservice.ExecuteQueries(qr);

                    string updateQr = $"update tblPRODUCT set quantity = {item.quantity + item.quantityInWareHouse} where ProductID = {item.id};";
                    dbservice.ExecuteQueries(updateQr);
                }

                dbservice.CloseDB();
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FormSelectProduct formSelectProduct = new FormSelectProduct(modeFormAddProduct.importProduct);
            formSelectProduct.ShowDialog();
            if (formSelectProduct.productModel != null)
            {
                var index = listProductModel.FindIndex(x => x.id == formSelectProduct.productModel.id);
                if (index != -1)
                {
                    listProductModel[index].quantity += formSelectProduct.productModel.quantity;

                    int rowIndex = -1;
                    foreach (DataGridViewRow row in DataGridView.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(formSelectProduct.productModel.id))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    DataGridView.Rows[rowIndex].Cells[3].Value = listProductModel[index].quantity.ToString();
                }
                else
                {
                    DataGridView.Rows.Add(formSelectProduct.productModel.id, formSelectProduct.productModel.productName, formSelectProduct.productModel.price, formSelectProduct.productModel.quantity);
                    listProductModel.Add(formSelectProduct.productModel);
                }
                totalPriceNum += (formSelectProduct.productModel.price * formSelectProduct.productModel.quantity);
                totalPrice.Text = totalPriceNum.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " VND";
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (listProductModel.Count == 0) { message.showWarning("Sản phẩm không được để trống"); return; }
            if (nameImport.Text == string.Empty)
            {
                message.showWarning("Tên phiếu nhập không được để trống ");
                return;
            }

            addNewRecord();
            this.Close();
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {

                DialogResult dr;
                dr = MessageBox.Show("Chắc chắn xóa dòng đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                {
                    int r = DataGridView.CurrentRow.Index;
                    string productID = DataGridView.Rows[r].Cells[0].Value.ToString();

                    var product = listProductModel.Find(x => x.id == productID);

                    totalPriceNum -= (product.price * product.quantity);
                    totalPrice.Text = totalPriceNum.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " VND";

                    listProductModel.Remove(product);
                    DataGridView.Rows.RemoveAt(r);



                }
            }
        }
    }

    public class ImportModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string total { get; set; }
        public string suplider { get; set; }
        public string dateImport { get; set; }
        public ImportModel() { }

        public ImportModel(string id, string name, string description, string total, string suplider, string dateImport)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.total = total;
            this.suplider = suplider;
            this.dateImport = dateImport;
        }

    }
}
