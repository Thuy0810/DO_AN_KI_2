using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class ProductDetils : Form
    {
        private string conStr = @"Data Source=.;Initial Catalog=DO_AN_KI2;Integrated Security=True";
        private SqlConnection mySqlConnection;
        private int id;
        private SqlCommand mySqlCommand;



        public ProductDetils(int id)
        {
            InitializeComponent();
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            this.id = id;
            addDataCategory();
            addDatTrademark();
            addDataSupplier();
        }

        void addDataCategory()
        {
            string query = "select * from tblCATEGORY;";
            using (SqlCommand command = new SqlCommand(query, mySqlConnection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // Đặt DataSource của ComboBox bằng DataTable thay vì toàn bộ DataSet
                    category.DataSource = dataSet.Tables[0]; // Sử dụng chỉ số 0 vì chỉ có một DataTable được trả về từ truy vấn

                    // Đặt ValueMember và DisplayMember cho ComboBox
                    category.ValueMember = "categoryID"; // Đặt tên của cột chứa giá trị
                    category.DisplayMember = "name"; // Đặt tên của cột bạn muốn hiển thị
                }
            }
        }
        void addDataSupplier()
        {
            string query = @"select * from tblSUPPLIER ";
            using (SqlCommand command = new SqlCommand(query, mySqlConnection))
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    supplier.DataSource = dataSet.Tables[0];
                    supplier.ValueMember = "supplierID";
                    supplier.DisplayMember = "supplierName";
                }
            }
        }

        void addDatTrademark()
        {
            string query = @"select * from tblTRADEMARK ";
            using(SqlCommand command = new SqlCommand(query, mySqlConnection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet datSet = new DataSet();
                    adapter.Fill(datSet);
                    trademark.DataSource = datSet.Tables[0];
                    trademark.ValueMember = "trademarkID";
                    trademark.DisplayMember = "nameT";
                }
            }
        }


        private void ProductDetils_Load(object sender, EventArgs e)
        {
            setControl(true);


            //string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.name, p.status, p.weight, p.description, p.isPhysic, p.img " +
            //      "FROM tblPRODUCT p " +
            //      "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
            //      "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
            //      "INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID" +
            //      "WHERE ProductID = @id";
            string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.categoryID, s.supplierName, t.trademarkID, s.supplierID, p.status, p.weight, p.description, p.isPhysic, p.img " +
                  "FROM tblPRODUCT p " +
                  "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
                  "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
                  "INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID " +
                  "WHERE ProductID = @id";


            using (SqlCommand command = new SqlCommand(query, mySqlConnection))
            {
                // Thêm tham số cho câu truy vấn
                command.Parameters.AddWithValue("@id", id);

                // Thực hiện truy vấn và nhận dữ liệu vào DataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                 

                    // Đọc dữ liệu từ DataReader
                    if (reader.Read())
                    {
                        // Lấy thông tin từ cột cụ thể trong truy vấn
                        string namePro = reader["nameProduct"].ToString();
                        int quantityPro =Convert.ToInt32( reader["quantity"].ToString());
                        int originPricePro = Convert.ToInt32(reader["originPrice"].ToString());
                        int picePro= Convert.ToInt32(reader["price"].ToString());
                        string categoryID = reader["categoryID"].ToString();
                        string supplierID = reader["supplierID"].ToString();
                        string trademarkID= reader["trademarkID"].ToString() ;
                        decimal weightPro = Convert.ToDecimal(reader["weight"].ToString());
                        string descriptionPro= reader["description"].ToString();
                        // Gán thông tin vào các TextBox trên Form B
                        txtNameP.Text = namePro;
                        txtQuantityP.Text= quantityPro.ToString();
                        txtOriginPrice.Text = originPricePro.ToString();
                        txtPrice.Text = picePro.ToString();
                        txtDescription.Text = descriptionPro.ToString();
                        txtWeight.Text = weightPro.ToString();
                       
                       
                        //category.Items.Add(categoryName);
                        category.SelectedValue = categoryID;

                       
                        supplier.SelectedValue = supplierID;

                       
                        trademark.SelectedValue = trademarkID;

                        int active = Convert.ToInt32(reader["status"]);
                        swActive.Checked = (active == 1); // Nếu status là 1 thì bật nút switch, ngược lại tắt

                        int physic = Convert.ToInt32(reader["isPhysic"]);
                        swPhysic.Checked=(physic == 1);

                        int limit = Convert.ToInt32(reader["status"]);
                        swLimit.Checked = (limit == 1);
                        // ...
                    }
                }
            }
        }
        private void setControl(bool status)
        {
            txtNameP.ReadOnly= status;
            txtQuantityP.ReadOnly = status;
            txtOriginPrice.ReadOnly = status;
            txtPrice.ReadOnly = status;
            txtDescription.ReadOnly = status;
            txtWeight.ReadOnly = status;
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            setControl(false);
           
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                // Lấy giá trị từ các điều khiển trên giao diện

                string nameProduct = txtNameP.Text;
                string description = txtDescription.Text;

                // Sử dụng parameterized query để tránh lỗ hổng SQL injection
                string query = $"UPDATE tblPRODUCT SET nameProduct = @nameProduct, Description = @description , categoryID = @categoryID ,status = @status where ProductID={id}"; // Thay đổi tblCATEGORY thành tên bảng của bạn

                SqlCommand command = new SqlCommand(query, connection);

                var idCategory = category.SelectedValue.ToString();
                int status = swActive.Checked ? 1 : 0;


                // Thêm các tham số và giá trị tương ứng vào câu lệnh SQL

                command.Parameters.AddWithValue("@nameProduct", nameProduct);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@categoryID",idCategory); // Đây là giả sử bạn muốn cập nhật dữ liệu của loại sản phẩm nào đó được chọn
                command.Parameters.AddWithValue("@status", status);

                // Thực thi câu lệnh SQL
                command.ExecuteNonQuery();

                
            }
        }


        //private void swActive_CheckedChanged(object sender, EventArgs e)
        //{
        //        int status= swActive.Checked ? 1 : 0;
        //    // Cập nhật giá trị status vào cơ sở dữ liệu
        //    using (SqlConnection connection = new SqlConnection(conStr))
        //    {
        //        connection.Open();
        //        string query = "UPDATE tblPRODUCT SET status = @status"; // Thay đổi tblCATEGORY thành tên bảng của bạn
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@status", status);
        //        command.ExecuteNonQuery();
        //    }
        // }
    }
}
