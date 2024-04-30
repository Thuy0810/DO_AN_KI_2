using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace DO_AN_KI_2
{
    public partial class watchProduct : Form
    {
        private string conStr = @"Data Source=.;Initial Catalog=DO_AN_KI2;Integrated Security=True";
        private SqlConnection connection;
       
        public watchProduct()
        {
            InitializeComponent();
        }

        private void watchProduct_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(conStr);
            connection.Open();
            DisplayP();
           
        }

        private void DisplayP()
        {
            string query = @"SELECT p.ProductID, p.nameProduct, p.img, p.quantity, p.originPrice, p.price, p.description, p.noLimit, p.isPhysic, p.weight, c.name AS categoryName, t.name AS tradeMarkName, p.status, s.supplierName
                    FROM tblPRODUCT p
                    INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID
                    INNER JOIN tblTRADEMARK t ON p.trademarkID = t.trademarkID
                    INNER JOIN tblSUPPLIER s ON p.supplierID = s.supplierID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Products");
                    DataTable dataTable = dataSet.Tables["Products"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int ProductID = Convert.ToInt32(row["ProductID"]);
                        string nameProduct = row["nameProduct"].ToString();
                        string img = row["img"].ToString();
                        int quantity = Convert.ToInt32(row["quantity"]);
                        int noLimit = Convert.ToInt32(row["noLimit"]);
                        int originPrice = Convert.ToInt32(row["originPrice"]);
                        int price = Convert.ToInt32(row["price"]);
                        string description = row["description"].ToString();
                        string categoryName = row["categoryName"].ToString();
                        string tradeMarkName = row["tradeMarkName"].ToString();
                        int isPhysic = Convert.ToInt32(row["isPhysic"]);
                        string DPhysic = (isPhysic == 1) ? "Có" : "Không";
                        decimal weight = Convert.ToDecimal(row["weight"]);
                        string DWeight = weight.ToString() + " kg";
                        int status = Convert.ToInt32(row["status"]);
                        string Dstatus = (status == 1) ? "Hoạt động" : "Không hoạt động";
                        string supplierName = row["supplierName"].ToString();

                        GnGrvWatch.Rows.Add(ProductID, nameProduct, img, quantity, originPrice, price, description, categoryName, tradeMarkName, DPhysic, DWeight, Dstatus, supplierName);
                      
                    }
                }
            }
        }
        
    }
}

