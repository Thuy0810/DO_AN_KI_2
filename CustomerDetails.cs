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
                string queryCustomerDetail = $"select * from tblCUSTOMER where customerID={id}";
                using(SqlCommand command= new SqlCommand(queryCustomerDetail, services.connection)) 
                {
                    command.Parameters.AddWithValue("customerID", id);
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

    }
}
