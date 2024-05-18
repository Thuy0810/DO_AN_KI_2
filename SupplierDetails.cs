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
    public partial class SupplierDetails : Form
    {
        DataServices services= new DataServices();
        private bool Modeview;
        private int id;
        private string oldPhone;
        private string oldEmail;

        public SupplierDetails(int id, bool Modeview)
        {
            InitializeComponent();
            this.id = id;
            this.Modeview = Modeview;
            btnEditsupplier.Visible = Modeview;
            btnSaveSupplier.Visible = !Modeview;
            services.OpenDB();
            SetControl(Modeview);
        }

        private void SupplierDetails_Load(object sender, EventArgs e)
        {
            if(Modeview)
            {

                string queryShowupplierDetails = $"select supplierID,supplierName,phone,email,adress from tblSUPPLIER where supplierID={id}";
                using(SqlCommand command= new SqlCommand(queryShowupplierDetails,services.connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader= command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            string SupplierName= reader["supplierName"].ToString();
                            string phone = reader["phone"].ToString();
                            string email= reader["email"].ToString();
                            string address= reader["adress"].ToString();

                            txtNameU.Text = SupplierName;
                            txtPhone.Text = phone;
                            txtEmail.Text = email;
                            txtAddress.Text = address;

                            oldEmail= txtEmail.Text;
                            oldPhone = txtPhone.Text;
                        }
                    }
                }
            }
        }

        private void SetControl(bool status)
        {
            txtAddress.ReadOnly = status;
            txtEmail.ReadOnly = status;
            txtNameU.ReadOnly = status;
            txtPhone.ReadOnly = status;

        }
        private void btnEditsupplier_Click(object sender, EventArgs e)
        {
           btnSaveSupplier.Visible=true;
            SetControl(false);
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            if(txtNameU.Text.Trim().Length == 0) 
            {
                services.ShowErrorMessageBox("Tên nhà cung cấp không được để trống");
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                services.ShowErrorMessageBox("Email không được để trống");
            }
            if (txtPhone.Text.Trim().Length == 0)
            {
                services.ShowErrorMessageBox("Số điện thoại không được để trống");
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                services.ShowErrorMessageBox("Địa chỉ không được để trống");
            }
            if(Modeview==true)
            {
                bool phoneChanged= !string.IsNullOrEmpty(txtPhone.Text.Trim()) && txtPhone.Text.Trim() != oldPhone;
                if (phoneChanged)
                {
                    string querySelectPhone = "select 1 from tblSUPPLIER where phone = @phone";
                    SqlCommand command= new SqlCommand(querySelectPhone,services.connection);
                    command.Parameters.AddWithValue("@phone",txtPhone.Text.Trim());
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.HasRows) 
                        {
                            services.ShowErrorMessageBox("Số điện thoại đã tồn tại, vui lòng kiểm tra lại");
                            reader.Close();
                            return;
                        }
                    }
                }
                bool EmailChanged= !string.IsNullOrEmpty(txtEmail.Text.Trim()) && txtEmail.Text.Trim() != oldEmail;
                if (EmailChanged)
                {
                    string querySelectEmail = "select 1 from tblSUPPLIER where email= @email";
                    SqlCommand command= new SqlCommand( querySelectEmail,services.connection);
                    command.Parameters.AddWithValue("@email",txtEmail.Text.Trim());
                    using(SqlDataReader reader = command.ExecuteReader())
                    { if(reader.HasRows)
                        {
                            services.ShowErrorMessageBox("Email đã tồn tại, vui lòng kiểm tra lại");
                            reader.Close();
                            return;
                        }
                    }
                }
                //sửa dữ liệu
                try
                {
                    services.OpenDB();
                    DialogResult dialog;
                    dialog= MessageBox.Show("Chắc chắn sửa dữ liệu ?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.No) return;

                    string queryUpdateSupplier = $"update tblSUPPLIER set supplierName =@supplierName,phone= @phone,email= @email,adress= @adress where supplierID={id}";
                    SqlCommand command= new SqlCommand(queryUpdateSupplier,services.connection);
                    command.Parameters.AddWithValue("@supplierName",txtNameU.Text.Trim());
                    command.Parameters.AddWithValue("@phone",txtPhone.Text.Trim());
                    command.Parameters.AddWithValue("@email",txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@adress",txtAddress.Text.Trim());

                    command.ExecuteNonQuery();
                    this.Close();

                }
                catch 
                {
                    services.ShowErrorMessageBox("Lỗi không thể sửa");
                }
            }
            else
            {
                string queryPhone = "select 1 from tblSUPPLIER where phone= @phone";
                SqlCommand command= new SqlCommand(queryPhone,services.connection);
                command.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                using( SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        services.ShowErrorMessageBox("Số điện thoại đã tồn tại, vui lòng kiểm tra lại.");
                        reader.Close();
                        return;
                    }
                }
                string queryEmail = "Select 1 from tblSUPPLIER where email= @email";
                SqlCommand command1= new SqlCommand(queryEmail,services.connection);
                command1.Parameters.AddWithValue("@email",txtEmail.Text.Trim());
                using(SqlDataReader reader = command1.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        services.ShowErrorMessageBox("Email đã tồn tại, vui lòng kiểm tra lại");
                        reader.Close();
                        return;
                    }
                }

                try
                {
                    services.OpenDB();
                    string queryAddSupplier = "insert into tblSUPPLIER (supplierName,phone,email,adress) values (@supplierName, @phone, @email, @adress)";
                    SqlCommand command2 = new SqlCommand(queryAddSupplier, services.connection);
                    command2.Parameters.AddWithValue("@supplierName", txtNameU.Text.Trim());
                    command2.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    command2.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    command2.Parameters.AddWithValue("@adress", txtAddress.Text.Trim());

                    command2.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch 
                {
                    services.ShowErrorMessageBox("Thêm không thành công");
                }
            }
        }
    }
}
