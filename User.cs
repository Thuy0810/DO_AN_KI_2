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
    public partial class User : Form
    {
        DataServices services = new DataServices();
        private int id;
        private bool Modeview;
        private bool EditMode;

        

        public User(int id, bool Modeview)
        {
            InitializeComponent();
            services.OpenDB();
            this.id = id;
            showDattaRole();
            btnEditU.Visible = Modeview;
            btnSave.Visible = !Modeview;
            setControl(Modeview);
            this.Modeview = Modeview;
            this.EditMode = !Modeview;
       
        }
        void showDattaRole()
        {
            string query = "select * from tblROLE";
            using (SqlCommand command= new SqlCommand(query,services.connection))
            {
                using(SqlDataAdapter adapter= new SqlDataAdapter(command))
                {
                    DataSet dataSet= new DataSet();
                    adapter.Fill(dataSet);
                    cboRole.DataSource = dataSet.Tables[0];
                    cboRole.ValueMember = "roleID";
                    cboRole.DisplayMember = "roleName";
                }
            }
        }
      
      
       
        private void User_Load(object sender, EventArgs e)
        {
            //this.ControlBox = false;
            if (Modeview) //
            {
                string query = "select u.fullName, u.sex,u.birthday,u.birthday,u.adress,u.dayStart,u.userName,u.userID,u.password,r.roleName, u.status,u.phone,u.email from tblUSER u inner join tblUSERROLE rl on u.userID= rl.userID inner join tblROLE r on r.roleID= rl.roleID where u.userID = @id";
                using (SqlCommand command=new SqlCommand(query,services.connection))
                {
                    // Thêm tham số cho câu truy vấn
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader= command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            string fullName= reader["fullName"].ToString(); 
                            string sex= reader["sex"].ToString();
                            DateTime birthday= Convert.ToDateTime(reader["birthday"]);
                            string adress = reader["adress"].ToString();
                            DateTime dayStart = Convert.ToDateTime(reader["dayStart"]);
                            string userName= reader["userName"].ToString();
                            string password= reader["password"].ToString();
                            string email= reader["email"].ToString();
                        
                            string phone = reader["phone"].ToString();

                            int status = Convert.ToInt32(reader["status"]);
                            swStatus.Checked = (status == 1);
                            //lay thong tin dien vao form
                            txtNameU.Text = fullName;
                            cboSex.SelectedItem = sex;
                            txtBirthday.Text = birthday.ToString("dd-MM-yyyy");
                            txtAddress.Text = adress;
                            txtStartday.Text = dayStart.ToString("dd-MM-yyyy");
                            txtEmail.Text = email;
                            txtPhone.Text = phone;
                            txtuserName.Text = userName;
                            txtPass.Text = password;

                        }
                    }
                }
            }
            
        } 
        public void setControl(bool status)
        {
            txtNameU.ReadOnly = status;
            txtBirthday.ReadOnly = status;
            txtAddress.ReadOnly = status;
            txtEmail.ReadOnly = status;
            txtPhone.ReadOnly = status;
            txtStartday.ReadOnly = status;
            txtPass.ReadOnly = status;
            txtuserName.ReadOnly = status;
            
        }
      
        private void btnEdit_Click(object sender, EventArgs e)
        {
            setControl(false);
            btnSave.Visible = true;
            EditMode = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //kiem tra thong tin nhap vao
            if(txtNameU.Text.Trim().Length ==0)
            {
                services.ShowErrorMessageBox("Họ tên không được để trống ");
               txtNameU.Focus();
                return;
            }
            if(txtAddress.Text.Trim().Length ==0)
            {
                services.ShowErrorMessageBox("Địa chỉ không được để trống");
                txtAddress.Focus();
                return ;
            }
            if(txtBirthday.Text.Trim().Length ==0)
            {
                services.ShowErrorMessageBox("Ngày sinh không được để trống");
                txtBirthday.Focus();
                return ;    
            }
            if(txtPass.Text.Trim().Length ==0)
            {
                services.ShowErrorMessageBox("Mật khẩu không được để trống");
                txtPass.Focus(); 
                return ;
            }
            if(txtStartday.Text.Trim().Length ==0)
            {
                services.ShowErrorMessageBox("Ngày vào làm không được để trống");
                txtStartday.Focus();
                return ;
            }
            if(txtuserName.Text.Trim().Length == 0)
            {
                services.ShowErrorMessageBox("UserName không được để trống");
                txtuserName.Focus();
                return;
            }
            if(txtPhone.Text.Trim().Length == 0)
            {
                services.ShowErrorMessageBox("Số điện thoại không được để trống");
                txtPhone.Focus();
                return ; 
            }

            if(Modeview)
            {
                //Sua du lieu
            }
            else
            {
                //Them moi
            }
        }
    }
}
