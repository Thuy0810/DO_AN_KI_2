using System;
using System.Data;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Trademark : Form
    {
        DataServices services = new DataServices();
        public Trademark()
        {
            InitializeComponent();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Trademark_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            string query = "Select * from tblTRADEMARK";
            DataTable dataTable = (DataTable)services.ShowObjectData(query);
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView.Rows.Add((string)row["trademarkID"].ToString(), (string)row["nameT"], (string)row["description"], Properties.Resources.Delete2);
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
        }
    }
}
