using LauncherApp;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BaseServer
{
    internal static class Database
    {
        private static string ConnectionString =
            "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True";

        public static string RegisterUser(Request request)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
            }
            catch (Exception e) { Console.WriteLine(e); }
            string queryString = "SELECT username FROM dbo.[Users] where username = @username;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", request.Username);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                    return JsonConvert.SerializeObject(new Request(){Success = false, FailureMessage = "User alread exists"});
            }

            queryString =
                "INSERT INTO dbo.[Users] (username, password, level) VALUES (@username, @password, @level);";
            SqlCommand insertCommand = new SqlCommand(queryString, Connection);
            insertCommand.Parameters.AddWithValue("@username", request.Username);
            insertCommand.Parameters.AddWithValue("@password", request.Password);
            insertCommand.Parameters.AddWithValue("@level", 0);
            insertCommand.ExecuteNonQuery();
            return JsonConvert.SerializeObject(new Request(){Success = true});
        }

        public static string LoginUser(Request request)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            try { 
                Connection.Open();
            }
            catch(Exception e) { Console.WriteLine(e); }
            string queryString = "SELECT username, level FROM dbo.[Users] where username = @username and password = @password;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", request.Username);
            command.Parameters.AddWithValue("@password", request.Password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return JsonConvert.SerializeObject(new Request(){Username = request.Username,Level = reader.GetInt32(1),Success = true});
                }
            }
            return JsonConvert.SerializeObject(new Request(){Success = false, FailureMessage = "Invalid username or password"});
        }

        public static void UpdateUserLevel(User user)
        {

        }

        public static void UpdateUserGames(User user)
        {

        }
          
    }
}
