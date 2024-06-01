using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    public class DataServices
    {
        private string Sql = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=DO_AN_KI2;Integrated Security=True";
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


        /// <summary>
        /// Dùng khi add with value (chống injection) 
        /// </summary>
        /// <param name="query">Lưu ý mỗi param phải cách (ví dụ @param )</param>
        /// <param name="parameter">màng object , giá trị lần lượt tương ứng với value trong query</param>
        /// <returns></returns>
        public object ExecuteQueryWithValue(string query, object[] parameter = null)
        {


            using (SqlConnection connection = new SqlConnection(Sql))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }

                return new object { };
            }
        }

    }
}
