using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DO_AN_KI_2
{
    public partial class AllProduct : Form
    {
        private string conStr = @"Data Source=.;Initial Catalog=DO_AN_KI2;Integrated Security=True";
        private SqlConnection mySqlConnection;
        
        public AllProduct()
        {
            InitializeComponent();
            GnDtP.CellDoubleClick += GnDtP_CellClick;
        }

        private void AllProduct_Load(object sender, EventArgs e)
        {
            //this.ControlBox=false;
            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            Display();

        }

        private  void Display()
        {
            string query = "SELECT p.nameProduct, p.quantity, p.originPrice, p.price, p.noLimit, c.name, p.status " +
                           "FROM tblPRODUCT p " +
                           "INNER JOIN tblCATEGORY c ON p.categoryID = c.categoryID";




            using (SqlCommand command = new SqlCommand(query, mySqlConnection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Products");
                    DataTable dataTable = dataSet.Tables["Products"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string productName = row["nameProduct"].ToString();
                        int quantity = Convert.ToInt32(row["quantity"]);
                        int originPrice = Convert.ToInt32(row["originPrice"]);
                        int price = Convert.ToInt32(row["price"]);
                        int noLimit = Convert.ToInt32(row["noLimit"]);
                        string display=(noLimit == 1)? "Không giới hạn ":quantity.ToString();
                        string nameCategory = row["name"].ToString();
                        int status= Convert.ToInt32(row["status"]);
                        string dispStatus = (status == 1) ? "Hoạt động" : "Không hoạt động ";
                        foreach (DataGridViewColumn column in GnDtP.Columns)
                        {
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        Console.WriteLine($"Name: {productName}, Price: {price}");
                        GnDtP.Rows.Add(productName,display, originPrice, price, nameCategory, dispStatus);
                    }
                }
            }

            for (int row = 0; row <= GnDtP.Rows.Count - 1; row++)
            {
                ((DataGridViewImageCell)GnDtP.Rows[row].Cells[6]).Value = Properties.Resources.Eye1;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            watchProduct watch= new watchProduct();
            watch.Show();
        }

        private void GnDtP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                // Retrieve data from the clicked row
                for (int row = 0; row <= GnDtP.Rows.Count - 1; row++)
                {
                    string data = ((DataGridViewImageCell)GnDtP.Rows[row].Cells[6]).Value.ToString();
                }

                    // Create an instance of the new form
                    ProductDetils newForm = new ProductDetils();

                // Pass data to the new form
                //newForm.Data = data;

                // Display the new form
                newForm.ShowDialog();
            }
        }
    }
}
