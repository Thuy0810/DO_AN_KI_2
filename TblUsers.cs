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
    public partial class TblUsers : Form
    {
        DataServices services= new DataServices();
        public TblUsers()
        {
            InitializeComponent();
        }

        private void TblUsers_Load(object sender, EventArgs e)
        {
           // this.ControlBox = false;
           services.OpenDB();
            DisplayUser();

        }
        private void DisplayUser()
        {
            string query = @" select tblUSER.userID,tblROLE.roleName, fullName, userName, password, phone from tblUSER inner join tblUSERROLE on tblUSER.userID  = tblUSERROLE.userID inner join tblROLE on tblROLE.roleID= tblUSERROLE.roleID";

            using (SqlCommand command = new SqlCommand(query, services.connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "User");
                    DataTable dataTable = dataSet.Tables["User"];
                    GnDtUser.Rows.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {

                        int id = Convert.ToInt32(row["userID"]);
                        string fullrName = row["fullName"].ToString();
                        string userName = row["userName"].ToString();
                        string password = row["password"].ToString();
                        string phone = row["phone"].ToString();
                        string role =row["roleName"].ToString();
                       
                        foreach(DataGridViewColumn column in GnDtUser.Columns)
                        {
                            column.HeaderCell.Style.Alignment= DataGridViewContentAlignment.MiddleCenter;
                        }
                        GnDtUser.Rows.Add(id, fullrName, userName, password, phone, role);
                    }
                }
            }
            for(int row=0; row<=GnDtUser.Rows.Count-1; row++)
            {
                ((DataGridViewImageCell)GnDtUser.Rows[row].Cells[6]).Value = Properties.Resources.Delete2;
            }
        }

        private void GnDtUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GnDtUser.ReadOnly = true;
            if (e.RowIndex >= 0)
            {
                string id = GnDtUser.Rows[e.RowIndex].Cells[0].Value.ToString();
                User user = new User(Convert.ToInt32(id), true);
                user.ShowDialog();
                DisplayUser();

            }
        }
    }
}
