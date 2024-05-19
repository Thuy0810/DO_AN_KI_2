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
    public partial class Customer : Form
    { DataServices services= new DataServices();
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            //this.ControlBox = false;
            services.OpenDB();
            DisplayCustomer();
        }
        private void DisplayCustomer()
        {
            try
            {
                string queryCustomer = " select * from tblCUSTOMER ";
                using (SqlCommand command = new SqlCommand(queryCustomer, services.connection)) 
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet= new DataSet();
                        adapter.Fill(dataSet,"Customer");
                        DataTable dataTable = dataSet.Tables["Customer"];
                        GnDtCustomer.Rows.Clear();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int id = Convert.ToInt32(row["customerID"]);
                            string nameCustomer = row["customerName"].ToString();
                            string phone= row["phone"].ToString() ;
                            string address = row["adress"].ToString();
                            GnDtCustomer.Rows.Add(id, nameCustomer, phone, address);
                        }                     
                    }
                }
                for(int row=0; row<=GnDtCustomer.Rows.Count-1; row++)
                {
                    ((DataGridViewImageCell)GnDtCustomer.Rows[row].Cells[4]).Value = Properties.Resources.Delete2;
                }
            }
            catch
            { 
                
            }
        }
    }
}
