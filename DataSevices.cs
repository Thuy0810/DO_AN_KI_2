using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
namespace DO_AN_KI_2
{
    internal class DataSevices
    {
        // Khai báo đối tượng kết nối tới CSDl;
        private static SqlConnection SqlConnection;
        private SqlDataAdapter SqlDataAdapter;
        
        //Hàm kết nối tới CSDL;
        public bool OpenDB()
        {
            string query= @"Data Source=.;Initial Catalog=DO_AN_KI2;Integrated Security=True";
            try
            {
                SqlConnection = new SqlConnection(query);
                SqlConnection.Open();
            }
            catch(SqlException ex)
            { 

                SqlConnection= null;
                return false;
            }
            return true;
        }

        // hàm truy vấn dữ liệu;
        public DataTable RunQuery(string query)
        {
            DataTable dt = new DataTable(); 
           //try
           // {
               
              SqlDataAdapter = new SqlDataAdapter(query, SqlConnection);
                 // Cập nhật dữ liệu
               SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(SqlDataAdapter);
                SqlDataAdapter.Fill(dt);
            //}
            //catch (SqlException ex)
            //{
            //   //* DisplayError(ex);
            //    return null;
            //}
            return dt;
        }
        // Hàm nhập một DataTable vòa một bảng của CSDL;

     


        public void Update(DataTable dt)
        {
            try
            {
                SqlDataAdapter.Update(dt);
            }
            catch (SqlException ex)
            {
                ////DisplayError(ex);
            }
        }
        // Hàm thực hiện một câu lệnh Sql dựa trên Sql Command
        public void ExcuteNonQuery(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                //DisplayError(ex);
            }
            
        }
        //Hàm hiển thị lỗi;
        //public void DisplayError(SqlException ex)
        //{
        //    string query = "
        //    DataTable dtEr = RunQuery(query);
        //    if (dtEr.Rows.Count > 0)
        //    {
        //        MessageBox.Show(dtEr.Rows[0][1].ToString().Trim(), "Lỗi" + ex.Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    else
        //    {
        //        MessageBox.Show(ex.Message, "Error" + ex.Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
