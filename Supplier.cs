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
    public partial class Supplier : Form
    {
        DataServices services= new DataServices();
        public Supplier()
        {
            InitializeComponent();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
           // this.ControlBox = false;
            services.OpenDB();
            DisplaySupplier();
        }
        private void DisplaySupplier()
        {
            try
            {
                string QueryShowsSupplier = "select * from tblSUPPLIER";
                using (SqlCommand command= new SqlCommand(QueryShowsSupplier,services.connection))
                { 
                    using (SqlDataAdapter adapter= new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet,"Supplier");
                        DataTable dataTable = dataSet.Tables["Supplier"];
                        GnDtSupplier.Rows.Clear();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            GnDtSupplier.Rows.Add(row.ItemArray);
                        }

                    }
                }
                for (int row = 0; row <= GnDtSupplier.Rows.Count - 1; row++)
                {
                    ((DataGridViewImageCell)GnDtSupplier.Rows[row].Cells[5]).Value = Properties.Resources.Delete2;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GnDtSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            GnDtSupplier.ReadOnly = true;
            if (e.RowIndex >= 0)
            {
                string id = GnDtSupplier.Rows[e.RowIndex].Cells[0].Value.ToString();
                SupplierDetails supplierDetails = new SupplierDetails(Convert.ToInt32(id), true);
                supplierDetails.ShowDialog();
                DisplaySupplier();

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SupplierDetails supplierDetails = new SupplierDetails(0,false);
            supplierDetails.ShowDialog();
            DisplaySupplier();
        }

        private void txtSearcSupplier_TextChanged(object sender, EventArgs e)
        {
            for (int row = 0; row <= GnDtSupplier.Rows.Count - 1; row++)
            {
                ((DataGridViewImageCell)GnDtSupplier.Rows[row].Cells[5]).Value = Properties.Resources.Delete2;
            }
            try
            {
                if(string.IsNullOrEmpty(txtSearcSupplier.Text))
                {
                    DisplaySupplier();
                    return;
                }
                else
                {
                    services.OpenDB();
                    string querySearchSupplier = "select * from tblSUPPLIER where supplierName like @supplierName";
                    SqlCommand command= new SqlCommand(querySearchSupplier, services.connection);
                    command.Parameters.AddWithValue("@supplierName", "%" + txtSearcSupplier.Text.Trim('\'') + "%");
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet,"Supplier");
                        DataTable dataTable = dataSet.Tables["Supplier"];
                        GnDtSupplier.Rows.Clear();
                        foreach(DataRow row in dataTable.Rows)
                        {
                            int id= Convert.ToInt32(row["supplierID"]);
                            string suplierName= row["supplierName"].ToString();
                            string phone = row["phone"].ToString();
                            string email= row["email"].ToString() ;
                            string adress= row["adress"].ToString() ;
                            GnDtSupplier.Rows.Add(id, suplierName, phone, emailC, adress);
                        }   
                    }
                }
            }
            catch 
            {
                services.ShowErrorMessageBox("Có lỗi xảy ra");
            }
        }

        private void GnDtSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Chắc chắn xóa nhà cung cấp đã chọn không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No) return;

              int r=GnDtSupplier.CurrentRow.Index;
              string supplierID= GnDtSupplier.Rows[r].Cells[0].Value.ToString();
                string quyery2 = "delete from tblSUPPLIER where supplierID=" + supplierID;
                SqlCommand command1 = new SqlCommand(quyery2, services.connection);
                command1.ExecuteNonQuery();


                GnDtSupplier.Rows.Clear();
                DisplaySupplier();

            }
        }

        private void GnDtSupplier_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                GnDtSupplier.Cursor = Cursors.Hand;
            }
        }

        private void GnDtSupplier_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            GnDtSupplier.Cursor = Cursors.Default;
        }
    }
}
