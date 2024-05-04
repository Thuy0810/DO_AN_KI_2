using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DO_AN_KI_2
{
    public partial class ProductDetils : Form
    {
        private string conStr = @"Data Source=.;Initial Catalog=DO_AN_KI2;Integrated Security=True";
        private SqlConnection mySqlConnection;
        private int id;

        public ProductDetils()
        {
        }

        public ProductDetils(int id)
        {
            InitializeComponent();
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            this.id = id;

           
        }

       

        private void ProductDetils_Load(object sender, EventArgs e)
        {

            //string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.name, p.status, p.weight, p.description, p.isPhysic, p.img " +
            //      "FROM tblPRODUCT p " +
            //      "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
            //      "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
            //      "INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID" + 
            //      "WHERE ProductID = @id";   
            string query = "SELECT p.ProductID, p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.name, s.supplierName, t.nameT, p.status, p.weight, p.description, p.isPhysic, p.img " +
                  "FROM tblPRODUCT p " +
                  "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID " +
                  "INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID " +
                  "INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID " + // Thêm khoảng trắng ở đây
                  "WHERE ProductID = @id"; // Thêm khoảng trắng ở đây


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
                        string categoryName = reader["name"].ToString();
                        string supplierPro= reader["supplierName"].ToString();
                        string trademarkPro= reader["nameT"].ToString() ;
                        decimal weightPro = Convert.ToDecimal(reader["weight"].ToString());
                        string descriptionPro= reader["description"].ToString();
                        // Gán thông tin vào các TextBox trên Form B
                        txtNameP.Text = namePro;
                        txtQuantityP.Text= quantityPro.ToString();
                        txtOriginPrice.Text = originPricePro.ToString();
                        txtPrice.Text = picePro.ToString();
                        txtDescription.Text = descriptionPro.ToString();
                        txtWeight.Text = weightPro.ToString();
                       
                       
                        category.Items.Add(categoryName);
                        category.SelectedItem = categoryName;

                        supplier.Items.Add(supplierPro);
                        supplier.SelectedItem = supplierPro;

                        trademark.Items.Add(trademarkPro);
                        trademark.SelectedItem = trademarkPro;

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
