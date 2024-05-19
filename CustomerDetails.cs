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
    public partial class CustomerDetails : Form
    {
        DataServices services=new DataServices();
        private bool ModeView;
        private int id;
        private string oldPhone;
        private string oldEmail;
        public CustomerDetails(int id, bool ModeView)
        {
            InitializeComponent();
            this.id = id;
            this.ModeView = ModeView;
            services.OpenDB();
            btnEditCustomer.Visible = ModeView;
            btnSaveCustomer.Visible= !ModeView;
            setControl(ModeView);
        }
        
        private void CustomerDetails_Load(object sender, EventArgs e)
        {
           if(ModeView)
            {
                services.OpenDB();
                string queryCustomerDetail = $"select customerName, phone,email,adress from tblCUSTOMER where customerID={id}";
               SqlDataReader reader= services.DataReader(queryCustomerDetail);
               if(reader.Read())
                {
                  
                        string customerName = reader["customerName"].ToString();
                        string phone = reader["phone"].ToString();
                        string email = reader["email"].ToString();
                        string adress = reader["adress"].ToString();

                        txtNameCustomer.Text = customerName;
                        txtPhoneCustomer.Text = phone;
                        txtEmailCustomer.Text = email;
                        txtAddressCustomer.Text = adress;
                        
                    //
                        oldEmail =txtEmailCustomer.Text;
                       oldPhone=txtPhoneCustomer.Text;
                    services.CloseDB();
                }
                
            }
        }
        private void setControl(bool status)
        {
            txtNameCustomer.ReadOnly = status;
            txtPhoneCustomer.ReadOnly = status;
            txtEmailCustomer.ReadOnly = status;
            txtAddressCustomer.ReadOnly = status;
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (txtNameCustomer.Text.Trim().Length == 0)
            {
                message.showWarning("Họ tên Khách hàng không được để trống");
            }
            if (txtPhoneCustomer.Text.Trim().Length == 0)
            {
                message.showWarning("Số điện thoại Khách hàng không được để trống");
            }
            if (ModeView)
            {
                services.OpenDB();
                bool phoneChanged = !string.IsNullOrEmpty(txtPhoneCustomer.Text.Trim()) && txtPhoneCustomer.Text.Trim() != oldPhone;
                if (phoneChanged)
                {
                    string querySelectPhone = "select 1 from tblCUSTOMER where phone = @phone";
                    SqlCommand command = new SqlCommand(querySelectPhone, services.connection);
                    command.Parameters.AddWithValue("@phone", txtPhoneCustomer.Text.Trim());
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            services.ShowErrorMessageBox("Số điện thoại đã tồn tại, vui lòng kiểm tra lại");
                            reader.Close();
                            return;
                        }
                    }
                }

                bool emailCustomerChange= !string.IsNullOrEmpty(txtEmailCustomer.Text.Trim())&& txtEmailCustomer.Text.Trim() != oldEmail;   
                if (emailCustomerChange)
                {
                    string queryEmailCustomer = "Select 1 from tblCUSTOMER where email= @email";
                    SqlCommand command = new SqlCommand(queryEmailCustomer, services.connection);
                    command.Parameters.AddWithValue("@email", txtEmailCustomer.Text.Trim());
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                           message.showWarning("Email đã tồn tại, vui lòng kiểm tra lại");
                            reader.Close();
                            return;
                        }
                    }
                }
                try
                {
                    services.OpenDB();
                    DialogResult dialog;
                    dialog = MessageBox.Show("Chắc chắn sửa dữ liệu ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.No) return;

                    string queryUpdateSupplier = $"update tblCUSTOMER set customerName =@customerName,phone= @phone,email= @email,adress= @adress where customerID={id}";
                    SqlCommand command = new SqlCommand(queryUpdateSupplier, services.connection);
                    command.Parameters.AddWithValue("@customerName", txtNameCustomer.Text.Trim());
                    command.Parameters.AddWithValue("@phone", txtPhoneCustomer.Text.Trim());
                    command.Parameters.AddWithValue("@email", txtEmailCustomer.Text.Trim());
                    command.Parameters.AddWithValue("@adress", txtAddressCustomer.Text.Trim());

                    command.ExecuteNonQuery();
                    services.CloseDB();
                    this.Close();
                    services.CloseDB();
                }
                catch
                {
                   message.showError("Lỗi không thể sửa");
                }
            }
            else
            {
                string queryPhone = "select 1 from tblCUSTOMER where phone = @phone";
                SqlCommand command = new SqlCommand(queryPhone, services.connection);
                command.Parameters.AddWithValue("@phone", txtPhoneCustomer.Text.Trim());
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        message.showWarning("Số điện thoại đã tồn tại, vui lòng kiểm tra lại.");
                        reader.Close();
                        return;
                    }
                }
                string queryEmail = "Select 1 from tblCUSTOMER where email= @email";
                SqlCommand command1 = new SqlCommand(queryEmail, services.connection);
                command1.Parameters.AddWithValue("@email", txtEmailCustomer.Text.Trim());
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        message.showWarning("Email đã tồn tại, vui lòng kiểm tra lại");
                        reader.Close();
                        return;
                    }
                }

                try
                {
                    services.OpenDB();
                    string queryAddCustomer = "insert into tblCUSTOMER (customerName,phone,email,adress) values (@customerName, @phone, @email, @adress)";
                    SqlCommand command2 = new SqlCommand(queryAddCustomer, services.connection);
                    command2.Parameters.AddWithValue("@customerName", txtNameCustomer.Text.Trim());
                    command2.Parameters.AddWithValue("@phone", txtPhoneCustomer.Text.Trim());
                    command2.Parameters.AddWithValue("@email", txtEmailCustomer.Text.Trim());
                    command2.Parameters.AddWithValue("@adress", txtAddressCustomer.Text.Trim());

                    command2.ExecuteNonQuery();
                    message.showSucess("Lưu thành công");
                    this.Close();
                    services.CloseDB();
                }
                catch
                {
                    message.showError("Thêm không thành công");
                }

            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            btnSaveCustomer.Visible = true;
            setControl(false);
        }
    }
}
