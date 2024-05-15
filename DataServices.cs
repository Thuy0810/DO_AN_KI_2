using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ExcutteNonqueries()
        {
            SqlCommand command = new SqlCommand();
            command.ExecuteNonQuery();
        }
    }
}
