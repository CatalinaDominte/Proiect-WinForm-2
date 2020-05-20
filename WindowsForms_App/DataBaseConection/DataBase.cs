using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConection
{
    public class DataBase
    {
        private static SqlConnection connection = null;
        private DataBase() { }

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = "Data Source=.;Initial Catalog=DBWinFormm;Integrated Security=True";



                connection = new SqlConnection(connectionString);

            }


            return connection;
        }
    }
}
