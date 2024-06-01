using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DO_AN_KI_2
{
    public partial class Form8 : Form
    {
        bool modenew;
        DataServices services = new DataServices();
        public Form8(bool modenew = true)
        {
            InitializeComponent();
            this.modenew = modenew;
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNameU_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveCustomer_Click_1(object sender, EventArgs e)
        {
            string query = "insert into tblTRADEMARK values ( @NAME , @decs );";
            services.ExecuteQueryWithValue(query, new string[] { txtNAME.Text, guna2TextBox1.Text });
            Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if (modenew)
            {
                label1.Text = "THÊM THƯƠNG HIỆU";
            }
            else
            {
                label1.Text = "XEM THƯƠNG HIỆU";
            }
        }
    }
}
