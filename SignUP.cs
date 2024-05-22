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
       
    public partial class SignUP : Form
    {
        DataServices services=new DataServices();
        public SignUP()
        {
            InitializeComponent();
        }

        private void SignUP_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            services.OpenDB();
            if(txtUserName.Text.Length==0)
            {
                message.showWarning("Tên người dùng không được để trống");
            }
            if (txtPass.Text.Length==0)
            {
                message.showWarning("Mật khẩu không được để trống");
            }

            string querySignUp = "select userName, password from tblUSER where userName= @userName and password=@password";
            SqlCommand command = new SqlCommand(querySignUp, services.connection);
            command.Parameters.AddWithValue("@userName", txtUserName.Text.Trim());
            command.Parameters.AddWithValue("@password", txtPass.Text.Trim());
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                }
            }

        }
    }
}
