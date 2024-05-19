using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public class DataServices
    {
        private string Sql = @"Data Source=.;Initial Catalog=DO_AN_KI2;Integrated Security=True";
        public SqlConnection connection { get; set; }
        public DataServices()
        {

        }

        public void OpenDB()
        {
            connection = new SqlConnection(Sql);
            connection.Open();
        }
        public void CloseDB()
        {
            connection.Close();
        }
        public void ShowErrorMessageBox(string errorMessage, string errorTitle = "Thông báo")
        {
            MessageBox.Show(errorMessage, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// dùng khi delete , cập nhật , hoặc insert
        /// </summary>
        /// <param name="Query_"></param>
        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// dùng khi cần lấy dữ liệu riêng lẻ 
        /// </summary>
        /// <param name="Query_"></param>
        /// <returns></returns>
        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        /// <summary>
        /// Dùng khi show liên quan đến datasource
        /// </summary>
        /// <param name="Query_"></param>
        /// <returns></returns>
        public object ShowObjectData(string Query_)
        {
            OpenDB();
            SqlDataAdapter dr = new SqlDataAdapter(Query_, Sql);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            CloseDB();
            return dataum;
        }


        // Method for logging errors in a file or a logging system.

    }
}
