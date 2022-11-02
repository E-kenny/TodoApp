
using System.Configuration;
using System.Data.SqlClient;

namespace TodoRepositories
{
    public class Db
    {
        public Db()
        {

        }
        ////public static string ConnectionString
        ////{
        ////    get
        ////    {
        ////        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MyTodoconnection"];
        ////        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(settings.ConnectionString);
        ////        sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
        ////        sb.ConnectTimeout = ConnectionTimeout > 0 ? ConnectionTimeout : sb.ConnectTimeout;
        ////        return sb.ToString();
        ////    }

        ////}

        public static SqlConnection GetSqlConnection()
        {
            //SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlConnection sqlConnection = new SqlConnection("data source=.; database=todo; integrated security=SSPI");
            
            sqlConnection.Open();
            return sqlConnection;
        }

        public static string ApplicationName { set; get; }

        public static int ConnectionTimeout { get; set; }

    }


}

