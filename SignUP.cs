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

            string querySignUp = "select fullName ,userID from tblUSER where userName= @userName and password= @password";
           
            SqlCommand command = new SqlCommand(querySignUp, services.connection);
            command.Parameters.AddWithValue("@userName", txtUserName.Text.Trim());
            command.Parameters.AddWithValue("@password", txtPass.Text.Trim());
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    isLogin = true;
                    string fullName = reader["fullName"].ToString();
                    string userID = reader["userID"].ToString();
                    
                    string queryRole = $"select roleID from tblUSERROLE where userID={userID}";
                    services.OpenDB();
                    SqlDataReader reader1 = services.DataReader(queryRole);
                    if (reader1.Read())
                    {
                        string role = reader1["roleID"].ToString();
                        Properties.Settings.Default.role = role;
                    }
      
                    
                    Properties.Settings.Default.fullName = fullName;
                    Properties.Settings.Default.userID = userID;
                    Properties.Settings.Default.Save();
                    

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
