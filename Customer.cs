using DO_AN_KI_2.service;
using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Customer : Form
    {
        DataServices services = new DataServices();
        List<CustomerModel> customerModels = new List<CustomerModel>();
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            services.OpenDB();
            DisplayCustomer();
        }
        public void DisplayCustomer()
        {
            try
            {
                string queryCustomer = " select * from tblCUSTOMER ";

                DataTable dataTable = (DataTable)services.ShowObjectData(queryCustomer);
                GnDtCustomer.Rows.Clear();
                customerModels.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int id = Convert.ToInt32(row["customerID"]);
                    string nameCustomer = row["customerName"].ToString();
                    string phone = row["phone"].ToString();
                    string address = row["adress"].ToString();
                    string email = row["email"].ToString();
                    customerModels.Add(new CustomerModel(id, nameCustomer, phone, email, address));
                    GnDtCustomer.Rows.Add(id, nameCustomer, phone, address, Properties.Resources.Delete2);
                }

            }
            catch
            {
                message.showError("Có lỗi khi hiển thị");
            }
        }

        private void GnDtCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Chắc chắn xóa nhà cung cấp đã chọn không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No) return;

                int r = GnDtCustomer.CurrentRow.Index;
                string supplierID = GnDtCustomer.Rows[r].Cells[0].Value.ToString();
                string quyery2 = "delete from tblCUSTOMER where customerID=" + supplierID;
                services.OpenDB();
                services.ExecuteQueries(quyery2);
                services.CloseDB();
                GnDtCustomer.Rows.Clear();
                DisplayCustomer();
            }
        }

        private void GnDtCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GnDtCustomer.ReadOnly = true;
            if (e.RowIndex >= 0)
            {
                string id = GnDtCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();

                CustomerDetails customerDetails = new CustomerDetails(Convert.ToInt32(id), true);
                customerDetails.ShowDialog();
                DisplayCustomer();
            }
        }

        private void GnDtCustomer_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                GnDtCustomer.Cursor = Cursors.Hand;
            }
        }

        private void GnDtCustomer_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            GnDtCustomer.Cursor = Cursors.Default;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CustomerDetails customerDetails = new CustomerDetails(0, false);
            customerDetails.ShowDialog();

            DisplayCustomer();
        }

        private void txtSearcCustomer_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtSearcCustomer.Text))
                {
                    DisplayCustomer();
                    return;
                }
                else

                {
                    services.OpenDB();
                    string querySearchSupplier = "select * from tblCUSTOMER where customerName like @customerName";
                    SqlCommand command = new SqlCommand(querySearchSupplier, services.connection);
                    command.Parameters.AddWithValue("@customerName", "%" + txtSearcCustomer.Text.Trim('\'') + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Customer");
                        DataTable dataTable = dataSet.Tables["Customer"];
                        GnDtCustomer.Rows.Clear();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int id = Convert.ToInt32(row["customerID"]);
                            string suplierName = row["customerName"].ToString();
                            string phone = row["phone"].ToString();
                            string adress = row["adress"].ToString();
                            GnDtCustomer.Rows.Add(id, suplierName, phone, adress, Properties.Resources.Delete2);
                        }
                    }

                }
            }
            catch
            {
                services.ShowErrorMessageBox("Có lỗi xảy ra");
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file excel để nhập";
            openFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls|CSV (Comma delimited) (*.csv)|*.csv";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //try
                //{
                string path = openFileDialog.FileName;
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile workbook = ExcelFile.Load(path);
                ExcelWorksheet worksheet = workbook.Worksheets[0];
                worksheet.Rows.Remove(0);
                foreach (ExcelRow row in worksheet.Rows)
                {
                    int id = (int)row.Cells[0].Value;
                    string name = (string)row.Cells[1].Value;
                    string phone = (string)row.Cells[2].Value;
                    string email = (string)row.Cells[3].Value;
                    string address = (string)row.Cells[4].Value;

                    string query = "insert into tblCUSTOMER (customerName,phone,email,adress) values ( @customerName , @phone , @email , @adress )";

                    services.ExecuteQueryWithValue(query, new string[] { name, phone, email, address });
                    //}
                }
                //catch
                //{
                //    message.showError("Lỗi");
                //}
                message.showSucess("Thành công");
                DisplayCustomer();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Title = "Xuất excel";
            saveFileDialog1.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls|CSV (Comma delimited) (*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathSave = saveFileDialog1.FileName;
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile workbook = new ExcelFile();
                ExcelWorksheet worksheet = workbook.Worksheets.Add("Danh sách khách hàng");

                worksheet.Cells[0, 0].Value = "Id";
                worksheet.Cells[0, 1].Value = "Tên khách hàng";
                worksheet.Cells[0, 2].Value = "Số điện thoại";
                worksheet.Cells[0, 3].Value = "email";
                worksheet.Cells[0, 4].Value = "địa chỉ";

                int row = 0;
                foreach (var item in customerModels)
                {
                    worksheet.Cells[++row, 0].Value = item.ID;
                    worksheet.Cells[row, 1].Value = item.name;
                    worksheet.Cells[row, 2].Value = item.phone;
                    worksheet.Cells[row, 3].Value = item.email;
                    worksheet.Cells[row, 4].Value = item.adress;

                }

                workbook.Save(pathSave);
                var res = message.showQuestion($"Thành công , file được lưu tại {pathSave} , ấn ok để mở file");
                if (res == DialogResult.OK)
                {
                    Process.Start(pathSave);
                }
            }
        }
    }
    class CustomerModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string adress { get; set; }

        public CustomerModel(int iD, string name, string phone, string email, string adress)
        {
            ID = iD;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.adress = adress;
        }
    }
}
