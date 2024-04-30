using LauncherApp;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BaseServer
{
    internal static class Database
    {
        private static SqlConnection? Connection;

        public static void Connect()
        { 
            if(Connection is not null) return;

            var connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";

            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public static string? RegisterUser(Request request)
        {
            string queryString = "SELECT username FROM dbo.[Users] where username = @username;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", request.Username);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) return null;
            }

            queryString = "INSERT INTO dbo.[Users] (username, password, level) VALUES (@username, @password, @level);";
            SqlCommand insertCommand = new SqlCommand(queryString, Connection);
            insertCommand.Parameters.AddWithValue("@username", request.Username);
            insertCommand.Parameters.AddWithValue("@password", request.Password);
            insertCommand.Parameters.AddWithValue("@level", 0);
            insertCommand.ExecuteNonQuery();
            return "1";
        }

        public static string? LoginUser(Request request)
        {
            string queryString = "SELECT username, level FROM dbo.[Users] where username = @username and password = @password;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", request.Username);
            command.Parameters.AddWithValue("@password", request.Password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return JsonConvert.SerializeObject(new User(request.Username,reader.GetInt32(1)));
                }
            }

            return null;
        }

        public static void UpdateUserLevel(User user)
        {

        }

        public static void UpdateUserGames(User user)
        {

        }
          
    }
}
