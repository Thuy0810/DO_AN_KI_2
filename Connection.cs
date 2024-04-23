using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DO_AN_KI_2
{
    class Connection
    {
        private static string stringConnection = @"Data Source=.;Initial Catalog=DO_AN_KI2;Integrated Security=True;Trust Server Certificate=True";
        public SqlConnection getConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
