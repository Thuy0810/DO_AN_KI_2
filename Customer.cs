using DO_AN_KI_2.service;
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
            this.ControlBox = false;
            services.OpenDB();
            DisplayCustomer();
        }
        private void DisplayCustomer()
        {
            try
            {
                string queryCustomer = " select * from tblCUSTOMER ";
                
                DataTable dataTable = (DataTable)services.ShowObjectData(queryCustomer);
                GnDtCustomer.Rows.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    int id = Convert.ToInt32(row["customerID"]);
                    string nameCustomer = row["customerName"].ToString();
                    string phone = row["phone"].ToString();
                    string address = row["adress"].ToString();
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
                string quyery2 = "delete from tblSUPPLIER where supplierID=" + supplierID;
                SqlCommand command1 = new SqlCommand(quyery2, services.connection);
                command1.ExecuteNonQuery();


                GnDtCustomer.Rows.Clear();
                DisplayCustomer();

            }
        }

        private void GnDtCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GnDtCustomer.ReadOnly = true;
            if(e.RowIndex >= 0)
            {
                string id= GnDtCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
               
                CustomerDetails customerDetails= new CustomerDetails(Convert.ToInt32(id), true);
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
            CustomerDetails customerDetails= new CustomerDetails(0,false);
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
                                GnDtCustomer.Rows.Add(id, suplierName, phone,  adress, Properties.Resources.Delete2);
                            }
                        }
                    
                }
            }
            catch
            {
                services.ShowErrorMessageBox("Có lỗi xảy ra");
            }
        }
    }
}
