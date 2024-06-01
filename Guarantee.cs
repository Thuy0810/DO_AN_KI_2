using System;
using System.Data;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Guarantee : Form
    {
        DataServices services = new DataServices();
        public Guarantee()
        {
            InitializeComponent();
        }

        void fetchData()
        {
            string qr = "select g.guaranteeID , g.productID , g.customerID , g.dateStart ,g.dateEnd , g.userID , p.nameProduct ,c.customerName , u.fullName as nameEmploy from tblGUARANTEE as g inner join tblPRODUCT as p on g.productID = p.ProductID inner join tblCUSTOMER as c on g.customerID = c.customerID inner join tblUSER as u on g.userID = u.userID;";
            DataTable dataTable = (DataTable)services.ShowObjectData(qr);
            dataGridView.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView.Rows.Add(((int)row["guaranteeID"]), (string)row["customerName"], (string)row["nameProduct"], ((DateTime)row["dateStart"]).ToString(), ((DateTime)row["dateEnd"]).ToString(), (string)row["nameEmploy"], Properties.Resources.Delete2, (int)row["customerID"], (int)row["productID"], (int)row["userID"]);
            }
        }

        private void Guarantee_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            fetchData();
        }

        private void exprotExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
