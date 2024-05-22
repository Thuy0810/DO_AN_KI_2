using DO_AN_KI_2.service;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DO_AN_KI_2
{

    public partial class SignUP : Form
    {
        DataServices services = new DataServices();
        public bool isLogin { get; set; } = false;
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
            if (txtUserName.Text.Length == 0)
            {
                message.showWarning("Tên người dùng không được để trống");
            }
            if (txtPass.Text.Length == 0)
            {
                message.showWarning("Mật khẩu không được để trống");
            }

            string querySignUp = "select 1 from tblUSER where userName= @userName and password=@password";
            SqlCommand command = new SqlCommand(querySignUp, services.connection);
            command.Parameters.AddWithValue("@userName", txtUserName.Text.Trim());
            command.Parameters.AddWithValue("@password", txtPass.Text.Trim());
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    isLogin = true;
                    this.Close();
                }
                else
                {
                    isLogin = false;
                    message.showError("Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            services.CloseDB();

        }
    }
}
