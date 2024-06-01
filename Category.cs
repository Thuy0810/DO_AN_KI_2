using System;
using System.Data;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Category : Form
    {
        DataServices services = new DataServices();
        public Category()
        {
            InitializeComponent();
        }


        private void Category_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            string query = "SELECT * from tblCATEGORY ";
            DataTable dataTable = (DataTable)services.ShowObjectData(query);
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView.Rows.Add((string)row["categoryID"].ToString(), (string)row["Name"], (string)row["description"], Properties.Resources.Delete2);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearcSupplier_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datagrUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
        }
    }
}
