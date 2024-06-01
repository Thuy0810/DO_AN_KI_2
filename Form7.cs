using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Form7 : Form
    {
        bool modenew;
        DataServices services = new DataServices();
        public Form7(bool modenew = true)
        {
            InitializeComponent();
            this.modenew = modenew;
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            if (modenew)
            {
                label1.Text = "THÊM LOẠI SẢN PHẨM";
            }
            else
            {
                label1.Text = "XEM LOẠI SẢN PHẨM";
            }
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            string query = "insert into tblCATEGORY values ( @name , @desc );";
             services.ExecuteQueryWithValue(query, new string[] { txtName.Text, guna2TextBox1.Text } );
            Close();

        }
    }
}
