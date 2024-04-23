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
        private SqlCommand mySqlCommand;

        public AllProduct()
        {
            InitializeComponent();
        }

        private void AllProduct_Load(object sender, EventArgs e)
        {

            mySqlConnection = new SqlConnection(conStr);
            mySqlConnection.Open();
            Display();
        }

        private void Display()
        {
            string query = "SELECT * FROM tblPRODUCT";
            mySqlCommand = new SqlCommand(query, mySqlConnection);
            SqlDataReader reader = mySqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(reader);
            guna2DataGridView1.DataSource = dataTable;
            reader.Close();
        }
    }
}
