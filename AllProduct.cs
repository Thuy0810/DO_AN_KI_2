using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace DO_AN_KI_2
{
    public partial class AllProduct : Form
    {
        DataServices services = new DataServices();


        public AllProduct()
        {
            InitializeComponent();

        }

        private void AllProduct_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            services.OpenDB();
            Display();

        }


        public void Display()
        {

            string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.name, c.categoryID, t.trademarkID, p.status, p.supplierID, p.weight, p.description, p.isPhysic, p.img " +
              "FROM tblPRODUCT p " +
              "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
              "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
              "INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID";




            using (SqlCommand command = new SqlCommand(query, services.connection))
            {
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
                        string dispStatus = (status == 1) ? "Hoạt động" : "Không hoạt động ";
                        foreach (DataGridViewColumn column in GnDtP.Columns)
                        {
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                        GnDtP.Rows.Add(id, productName, display, originPrice, price, nameCategory, dispStatus);
                    }
                }
            }

            for (int row = 0; row <= GnDtP.Rows.Count - 1; row++)
            {
                ((DataGridViewImageCell)GnDtP.Rows[row].Cells[7]).Value = Properties.Resources.Delete2;
            }

        }





        private void guna2Button1_Click(object sender, EventArgs e)
        {

            ProductDetils Add = new ProductDetils(0, false);


            Add.ShowDialog();
            Display();
        }

        private void GnDtP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GnDtP.ReadOnly = true;
            if (e.RowIndex >= 0)
            {
                string id = GnDtP.Rows[e.RowIndex].Cells[0].Value.ToString();

                ProductDetils details = new ProductDetils(Convert.ToInt32(id), true);


                details.ShowDialog();
                Display();
            }
        }

        private void GnDtP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {

                DialogResult dr;
                dr = MessageBox.Show("Chắc chắn xóa dòng đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                {
                    int r = GnDtP.CurrentRow.Index;
                    string productID = GnDtP.Rows[r].Cells[0].Value.ToString();
                    string query = "Delete from tblPRODUCT where ProductID = " + productID;
                    SqlCommand command1 = new SqlCommand(query, services.connection);
                    command1.ExecuteNonQuery();
                    GnDtP.Rows.Clear();
                    Display();

                }
            }
        }

        private void GnDtP_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0) // Đảm bảo chỉ xử lý khi di chuột vào ô dữ liệu, không phải tiêu đề cột hoặc hàng
            {
                GnDtP.Cursor = Cursors.Hand; // Thiết lập con trỏ chuột thành hình bàn tay
            }
        }

        private void GnDtP_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            GnDtP.Cursor = Cursors.Default;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    // Hiển thị bảng ban đầu khi txtSearch trống
                    Display();
                    return;
                }
                if (txtSearch.Text != string.Empty)
                {

                    services.OpenDB();
                    string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.name, c.categoryID, t.trademarkID, p.status, p.supplierID, p.weight, p.description, p.isPhysic, p.img " +
                  "FROM tblPRODUCT p " +
                  "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
                  "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
                  "INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID where nameProduct like @nameProduct";

                    using (SqlCommand command = new SqlCommand(query, services.connection))
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

                                foreach (DataGridViewColumn column in GnDtP.Columns)
                                {
                                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                }

                                Console.WriteLine($"Name: {productName}, Price: {price}");
                                GnDtP.Rows.Add(id, productName, display, originPrice, price, nameCategory, dispStatus);

                            }
                        }
                        for (int row = 0; row <= GnDtP.Rows.Count - 1; row++)
                        {
                            ((DataGridViewImageCell)GnDtP.Rows[row].Cells[7]).Value = Properties.Resources.Delete2;
                        }
                    }
                }
                services.CloseDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error +{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GnDtP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


