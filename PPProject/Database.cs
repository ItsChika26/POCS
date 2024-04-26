using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PPProject
{
    internal static class Database
    {
        private static SqlConnection? Connection;
        //public SqlConnection connection;

        public static void Connect()
        { 
            if(Connection is not null) return;

            var connectionString = "Server=tcp:ppprojectserver.database.windows.net,1433;Initial Catalog=PPProject;Persist Security Info=False;User ID=ppprojectadmin;Password=S473server;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public static bool RegisterUser(string username, string password)
        {
            string queryString = "SELECT username FROM dbo.[Users] where username = @username;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", username);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) return false;
            }

            queryString = "INSERT INTO dbo.[Users] (username, password, level) VALUES (@username, @password, @level);";
            SqlCommand insertCommand = new SqlCommand(queryString, Connection);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.Parameters.AddWithValue("@level", 0);
            insertCommand.ExecuteNonQuery();
            return true;
        }

        public static User? LoginUser()
        {
            return new User("","");
        }

        public static void UpdateUserLevel(User user)
        {

        }

        public static void UpdateUserGames(User user)
        {

        }




          
    }
}
