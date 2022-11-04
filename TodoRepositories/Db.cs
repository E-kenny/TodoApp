
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlClient;

namespace TodoRepositories
{
    public class Db
    {
        public Db()
        {

        }
        
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("data source=.; database=todo; integrated security=SSPI");
            
            sqlConnection.Open();
            return sqlConnection;
        }

        public static string ApplicationName { set; get; }

        public static int ConnectionTimeout { get; set; }

    }


}

