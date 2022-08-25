using Microsoft.AspNetCore.Connections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PersonalWebApp.Models
{
    public static class SqlManager
    {
        private static SqlConnection _sqlConnection = new SqlConnection();

        public static ConnectionState ConnectionState
        {
            get
            {
                return _sqlConnection.State;
            }
        }

        public static void Connect(string connectionString)
        {
            if (connectionString == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _sqlConnection.ConnectionString = connectionString;
                _sqlConnection.Open();
            }
        }

        public static void Disconnect()
        {
            _sqlConnection.Close();
        }

        public static int ExecuteNonQuery(string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command, _sqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
