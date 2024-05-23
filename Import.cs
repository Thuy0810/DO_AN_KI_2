using System;
using System.Data;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public partial class Import : Form
    {
        DataServices dbService = new DataServices();
        public Import()
        {
            InitializeComponent();
        }

        private void fetchData()
        {
            string query = "select * from tblImportProduct as imp inner join tblSUPPLIER as sup on imp.supplierID = sup.supplierID;";

            DataTable dataTable = (DataTable)dbService.ShowObjectData(query);
            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["ImportProductID"].ToString();
                string name = Convert.ToString(row["Name"]);
                string description = Convert.ToString(row["Description"]);
                string total = row["total"].ToString() + " VND";
                string nameSuplider = row["supplierName"].ToString();
                string idSuplider = row["supplierID"].ToString();
                string dateImport = row["dateImport"].ToString();
                DataGridView.Rows.Add(id, name, description, total, nameSuplider, idSuplider, dateImport, Properties.Resources.Delete2);
            }
        }

        private void Import_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            fetchData();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ImportDetail import = new ImportDetail(null, true);
            import.ShowDialog();
            DataGridView.Rows.Clear();
            fetchData();

        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                string id = DataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                string name = DataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string description = DataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                string total = DataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                string suplider = DataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                string dateImport = DataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                ImportDetail imp = new ImportDetail(new ImportModel(id, name, description, total, suplider, dateImport));

                imp.ShowDialog();
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {

                DialogResult dr;
                dr = MessageBox.Show("Chắc chắn xóa dòng đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                {
                    int r = DataGridView.CurrentRow.Index;
                    string id = DataGridView.Rows[r].Cells[0].Value.ToString();
                    string query = $"delete from tblImportProduct where tblImportProduct.ImportProductID = '{id}';";

                    dbService.OpenDB();
                    dbService.ExecuteQueries(query);
                    dbService.CloseDB();
                    DataGridView.Rows.RemoveAt(r);
                }
            }
        }

        private void txtSearcSupplier_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtSearch.Text))
            //{
            //    fetchData();
            //    return;
            //}

            string query = $"select * from tblImportProduct as imp inner join tblSUPPLIER as sup on imp.supplierID = sup.supplierID where imp.name like N'%{txtSearch.Text.Replace("'", "\'\'")}%';";

            DataGridView.Rows.Clear();

            DataTable dataTable = (DataTable)dbService.ShowObjectData(query);
            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["ImportProductID"].ToString();
                string name = Convert.ToString(row["Name"]);
                string description = Convert.ToString(row["Description"]);
                string total = row["total"].ToString() + " VND";
                string nameSuplider = row["supplierName"].ToString();
                string idSuplider = row["supplierID"].ToString();
                string dateImport = row["dateImport"].ToString();
                DataGridView.Rows.Add(id, name, description, total, nameSuplider, idSuplider, dateImport, Properties.Resources.Delete2);
            }
        }
    }
}
