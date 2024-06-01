using DO_AN_KI_2.service;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class User : Form
    {
        DataServices services = new DataServices();
        private int id;
        private bool Modeview;
        private string olduserName;
        private string OldPhone;


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


        }
        void showDattaRole()
        {
            string query = "select * from tblROLE";
            using (SqlCommand command = new SqlCommand(query, services.connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    cboRole.DataSource = dataSet.Tables[0];
                    cboRole.ValueMember = "roleID";
                    cboRole.DisplayMember = "roleName";
                }
            }
        }



        private void User_Load(object sender, EventArgs e)
        {
            this.ControlBox = true;
            if (Modeview) //
            {

                string query = $"select u.fullName, u.sex,u.birthday,u.birthday,u.adress,u.dayStart,u.userName,u.userID,u.password,r.roleID, u.status,u.phone,u.email from tblUSER u inner join tblUSERROLE rl on u.userID= rl.userID inner join tblROLE r on r.roleID= rl.roleID where u.userID = {id}";
                using (SqlCommand command = new SqlCommand(query, services.connection))
                {

                    // Thêm tham số cho câu truy vấn

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            string fullName = reader["fullName"].ToString();
                            string sex = reader["sex"].ToString();
                            DateTime birthday = Convert.ToDateTime(reader["birthday"]);
                            string adress = reader["adress"].ToString();
                            DateTime dayStart = Convert.ToDateTime(reader["dayStart"]);
                            string userName = reader["userName"].ToString();
                            string password = reader["password"].ToString();
                            string email = reader["email"].ToString();
                            string roleId = reader["roleID"].ToString();
                            cboRole.SelectedValue = roleId;
                            string phone = reader["phone"].ToString();

                            int status = Convert.ToInt32(reader["status"]);
                            swStatus.Checked = (status == 1);
                            //lay thong tin dien vao form
                            txtNameU.Text = fullName;
                            cboSex.SelectedItem = sex;
                            DBirthday.Value = birthday;
                            txtAddress.Text = adress;
                            DstartDay.Value = dayStart;
                            txtEmail.Text = email;
                            txtPhone.Text = phone;
                            txtuserName.Text = userName;
                            txtPass.Text = password;


                            olduserName = txtuserName.Text;
                            OldPhone = txtPhone.Text;
                        }
                    }
                }
            }

        }
        public void setControl(bool status)
        {
            txtNameU.ReadOnly = status;
            // DstartDay.Enabled = status;
            txtAddress.ReadOnly = status;
            txtEmail.ReadOnly = status;
            txtPhone.ReadOnly = status;
            //  DBirthday.Enabled = status;
            txtPass.ReadOnly = status;
            txtuserName.ReadOnly = status;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setControl(false);
            btnSave.Visible = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //kiem tra thong tin nhap vao
            if (txtNameU.Text.Trim().Length == 0)
            {
                message.showWarning("Họ tên không được để trống ");
                txtNameU.Focus();
                return;
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                message.showWarning("Địa chỉ không được để trống");
                txtAddress.Focus();
                return;
            }

            if (txtPass.Text.Trim().Length == 0)
            {
                message.showWarning("Mật khẩu không được để trống");
                txtPass.Focus();
                return;
            }

            if (txtuserName.Text.Trim().Length == 0)
            {
                message.showWarning("UserName không được để trống");
                txtuserName.Focus();
                return;
            }

            if (txtPhone.Text.Trim().Length == 0)
            {
                message.showWarning("Số điện thoại không được để trống");
                txtPhone.Focus();
                return;
            }
            if (cboSex.SelectedIndex == -1)
            {
                // Không có mục nào được chọn trong ComboBox
                // Thực hiện xử lý tương ứng ở đây
                message.showWarning("Vui lòng chọn giới tính.");
                return;
            }
            if (Modeview == true)
            {


                bool userNameChanged = !string.IsNullOrEmpty(txtuserName.Text) && txtuserName.Text != olduserName;

                if (userNameChanged)
                {

                    string queryCheckUserName = "SELECT COUNT(*) FROM tblUSER WHERE userName = @userName";
                    SqlCommand commandCheckUserName = new SqlCommand(queryCheckUserName, services.connection);
                    commandCheckUserName.Parameters.AddWithValue("@userName", txtuserName.Text);

                    int count = (int)commandCheckUserName.ExecuteScalar();
                    if (count > 0)
                    {

                        message.showWarning("Tên người dùng này đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn một tên người dùng khác.");
                        return; // Dừng việc lưu trữ và thoát khỏi phương thức
                    }
                }
                bool phoneChanged = !string.IsNullOrEmpty(txtPhone.Text) && txtPhone.Text != OldPhone;
                if (phoneChanged)
                {
                    string queryCheckPhone = "Select count(*) from tblUSER where phone= @phone";
                    SqlCommand commandCheckPhone = new SqlCommand(queryCheckPhone, services.connection);

                    commandCheckPhone.Parameters.AddWithValue("@phone", txtPhone.Text);
                    int countPhone = (int)commandCheckPhone.ExecuteScalar();
                    if (countPhone > 0)
                    {
                        message.showWarning("Số điện thoại đã tồn tại, vui lòng nhập lại.");
                        return;
                    }
                }


            }
            if (Modeview == false)
            {

                string sSqlUserName = "SELECT 1 FROM tblUSER WHERE userName = @userName";
                SqlCommand commandCheckUserName = new SqlCommand(sSqlUserName, services.connection);
                commandCheckUserName.Parameters.AddWithValue("@userName", txtuserName.Text);

                using (SqlDataReader reader = commandCheckUserName.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        message.showWarning("Tên người dùng này đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn một tên người dùng khác.");
                        txtuserName.Focus();
                        reader.Close();
                        return;
                    }
                    reader.Close();
                }

                // Kiểm tra phone trùng lặp
                string sSqlPhone = "SELECT 1 FROM tblUSER WHERE phone = @phone";
                SqlCommand commandCheckPhone = new SqlCommand(sSqlPhone, services.connection);
                commandCheckPhone.Parameters.AddWithValue("@phone", txtPhone.Text);

                using (SqlDataReader reader = commandCheckPhone.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        message.showWarning("Số điện thoại này đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn một số điện thoại khác.");
                        txtPhone.Focus();
                        reader.Close();
                        return;
                    }
                    reader.Close();
                }
            }


            if (Modeview)
            {
                //Sua du lieu
                try
                {
                    services.OpenDB();
                    DialogResult dr = MessageBox.Show("Lưu thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                    string query = "UPDATE tblUSER SET fullName = @fullName, userName = @userName, password = @password, sex = @sex, ";
                    query += "phone = @phone, email = @email, adress = @address, ";
                    query += "birthday = @birthday, dayStart = @dayStart, status = @status WHERE userID = @userID";
                    SqlCommand command = new SqlCommand(query, services.connection);
                    command.Parameters.AddWithValue("@userID", id);
                    command.Parameters.AddWithValue("@fullName", txtNameU.Text);
                    command.Parameters.AddWithValue("@userName", txtuserName.Text);
                    command.Parameters.AddWithValue("@password", txtPass.Text);
                    command.Parameters.AddWithValue("@sex", cboSex.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@email", txtEmail.Text);
                    command.Parameters.AddWithValue("@address", txtAddress.Text);
                    command.Parameters.AddWithValue("@birthday", DBirthday.Value);
                    command.Parameters.AddWithValue("@dayStart", DstartDay.Value);
                    command.Parameters.AddWithValue("@status", swStatus.Checked ? 1 : 0);
                    command.ExecuteNonQuery();


                    string selectedRoleName = cboRole.Text;
                    string queryRole = "SELECT roleID FROM tblROLE WHERE roleName = @roleName";
                    SqlCommand commandRole = new SqlCommand(queryRole, services.connection);
                    commandRole.Parameters.AddWithValue("@roleName", selectedRoleName);
                    int newRoleID = (int)commandRole.ExecuteScalar();


                    string queryUserRole = "UPDATE tblUSERROLE SET roleID = @roleID WHERE userID = @userID";
                    SqlCommand commandUserRole = new SqlCommand(queryUserRole, services.connection);
                    commandUserRole.Parameters.AddWithValue("@userID", id);
                    commandUserRole.Parameters.AddWithValue("@roleID", newRoleID);
                    commandUserRole.ExecuteNonQuery();


                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể lưu thay đổi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                //Them moi
                try
                {
                    services.OpenDB();
                    DialogResult dialog = MessageBox.Show("Chắc chắn thêm mới người dùng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.No) return;



                    // Thêm người dùng vào bảng tblUSER
                    string insertUserQuery = @"INSERT INTO tblUSER (fullName, userName, password, phone, email, adress, status, dayStart, sex, birthday) 
                                VALUES (@fullName, @userName, @password, @phone, @email, @address, @status, @dayStart, @sex, @birthday);
                                SELECT SCOPE_IDENTITY();"; // Lấy userID mới
                    SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, services.connection);
                    insertUserCommand.Parameters.AddWithValue("@fullName", txtNameU.Text);
                    insertUserCommand.Parameters.AddWithValue("@userName", txtuserName.Text);
                    insertUserCommand.Parameters.AddWithValue("@password", txtPass.Text);
                    insertUserCommand.Parameters.AddWithValue("@phone", txtPhone.Text);
                    insertUserCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                    insertUserCommand.Parameters.AddWithValue("@address", txtAddress.Text);
                    insertUserCommand.Parameters.AddWithValue("@status", swStatus.Checked ? 1 : 0);
                    insertUserCommand.Parameters.AddWithValue("@dayStart", DstartDay.Value);
                    insertUserCommand.Parameters.AddWithValue("@sex", cboSex.SelectedItem);
                    insertUserCommand.Parameters.AddWithValue("@birthday", DBirthday.Value);

                    int newUserID = Convert.ToInt32(insertUserCommand.ExecuteScalar()); // Lấy userID mới


                    string getRoleIDQuery = "SELECT roleID FROM tblROLE WHERE roleName = @roleName";
                    SqlCommand getRoleIDCommand = new SqlCommand(getRoleIDQuery, services.connection);
                    getRoleIDCommand.Parameters.AddWithValue("@roleName", cboRole.Text);
                    int roleID = Convert.ToInt32(getRoleIDCommand.ExecuteScalar());


                    string insertUserRoleQuery = "INSERT INTO tblUSERROLE (userID, roleID) VALUES (@userID, @roleID)";
                    SqlCommand insertUserRoleCommand = new SqlCommand(insertUserRoleQuery, services.connection);
                    insertUserRoleCommand.Parameters.AddWithValue("@userID", newUserID);
                    insertUserRoleCommand.Parameters.AddWithValue("@roleID", roleID);

                    insertUserRoleCommand.ExecuteNonQuery();

                    MessageBox.Show("Thêm người dùng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Thêm không thành công: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
