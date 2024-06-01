using DO_AN_KI_2.service;
using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
namespace DO_AN_KI_2
{
    public partial class Guarantee : Form
    {
        DataServices services = new DataServices();
        List<GuaranteeModel> guaranteeModelslist = new List<GuaranteeModel>();
        public Guarantee()
        {
            InitializeComponent();
        }

        public void fetchData(string keySearch = "")
        {
            keySearch = $"%{keySearch}%";
            string qr = "select g.guaranteeID , g.productID , g.customerID , g.dateStart ,g.dateEnd , g.userID , p.nameProduct ,c.customerName , u.fullName as nameEmploy from tblGUARANTEE as g inner join tblPRODUCT as p on g.productID = p.ProductID inner join tblCUSTOMER as c on g.customerID = c.customerID inner join tblUSER as u on g.userID = u.userID where c.customerName like @keyword";


            DataTable dataTable = (DataTable)services.ExecuteQueryWithValue(qr, new string[] { keySearch });
            dataGridView.Rows.Clear();
            guaranteeModelslist.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                int guaranteeID = ((int)row["guaranteeID"]);
                string nameProduct = (string)row["nameProduct"];
                string customerName = (string)row["customerName"];
                DateTime dateStart = (DateTime)row["dateStart"];
                DateTime dateEnd = (DateTime)row["dateEnd"];
                string nameEmploy = (string)row["nameEmploy"];

                GuaranteeModel g = new GuaranteeModel(guaranteeID, nameProduct, customerName, dateStart, dateEnd, nameEmploy);
                guaranteeModelslist.Add(g);
                dataGridView.Rows.Add(guaranteeID, customerName, nameProduct, (dateStart).ToString(), (dateEnd).ToString(), nameEmploy, Properties.Resources.Delete2, (int)row["customerID"], (int)row["productID"], (int)row["userID"]);

            }
        }

        private void Guarantee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            fetchData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            fetchData(txtSearch.Text);
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
                ExcelWorksheet worksheet = workbook.Worksheets.Add("Danh sách bảo hành");

                worksheet.Cells[0, 0].Value = "Id";
                worksheet.Cells[0, 1].Value = "Tên khách hàng";
                worksheet.Cells[0, 2].Value = "Tên sản phẩm";
                worksheet.Cells[0, 3].Value = "Ngày bắt đầu bảo hành";
                worksheet.Cells[0, 4].Value = "Ngày kết thúc bảo hành";
                worksheet.Cells[0, 5].Value = "Người bán";

                int row = 0;
                foreach (var item in guaranteeModelslist)
                {
                    worksheet.Cells[++row, 0].Value = item.guaranteeID;
                    worksheet.Cells[row, 1].Value = item.customerName;
                    worksheet.Cells[row, 2].Value = item.nameProduct;
                    worksheet.Cells[row, 3].Value = item.dateStart;
                    worksheet.Cells[row, 4].Value = item.dateEnd;
                    worksheet.Cells[row, 5].Value = item.nameEmploy;

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

    class GuaranteeModel
    {
        public int guaranteeID { get; set; }
        public string customerName { get; set; }
        public string nameProduct { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public string nameEmploy { get; set; }

        public GuaranteeModel(int guaranteeID, string nameProduct, string customerName, DateTime dateStart, DateTime dateEnd, string nameEmploy)
        {
            this.guaranteeID = guaranteeID;
            this.nameProduct = nameProduct;
            this.customerName = customerName;
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
            this.nameEmploy = nameEmploy;
        }
    }
}
