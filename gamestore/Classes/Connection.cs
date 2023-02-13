using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace gamestore.Classes
{
    internal class Connection
    {
        public static SqlConnection sqlConnection = new SqlConnection(@"Data Source = NAYASHOV; Database = gamestore; Integrated Security=true;");
        public void OpenCon()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseCon()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetCon()
        {
            return sqlConnection;
        }
    }


}
