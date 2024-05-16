﻿using LauncherApp;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace BaseServer
{
    internal static class Database
    {
        
        private static string ConnectionString =
            "Data Source=DAYOLAPTOP\\POCS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public static Friend? GetFriend(string username, bool pending)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
            }
            catch (Exception e) { Console.WriteLine(e); }
            string queryString = "SELECT username, level,Online FROM dbo.[Users] where username = @username;";
            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", username);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    var friend_name = reader.GetString(0);
                    var level = reader.GetInt32(1);
                    var online = reader.GetBoolean(2);
                    var friend = new Friend(friend_name, level, online, pending);
                    return friend;
                }
            }
            return null;
        }
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
                "INSERT INTO dbo.[Users] (username, password, level, date_registered, XP) VALUES (@username, @password, @level, @date_registered, @XP);";
            SqlCommand insertCommand = new SqlCommand(queryString, Connection);
            insertCommand.Parameters.AddWithValue("@username", request.Username);
            insertCommand.Parameters.AddWithValue("@password", request.Password);
            insertCommand.Parameters.AddWithValue("@level", 0);
            insertCommand.Parameters.AddWithValue("@date_registered", DateTime.Now);
            insertCommand.Parameters.AddWithValue("@XP", 0);

            insertCommand.ExecuteNonQuery();
            return JsonConvert.SerializeObject(new Request(){Success = true});
        }

        public static string UpdateOnlineStatus(string username, bool status)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
            }
            catch (Exception e) { Console.WriteLine(e); }
            string queryString = "UPDATE dbo.[Users] SET Online = @online WHERE username = @username;";
            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@online", status);
            command.ExecuteNonQuery();
            return JsonConvert.SerializeObject(new Request(){Success = true});
        }
        public static string Logout(Request request)
        {
            UpdateOnlineStatus(request.Username, false);
            return JsonConvert.SerializeObject(new Request(){Success = true});
        }

        public static string LoginUser(Request request)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            try { 
                Connection.Open();
            }
            catch(Exception e) { Console.WriteLine(e); }
            string queryString = "SELECT username, level,Online FROM dbo.[Users] where username = @username and password = @password;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", request.Username);
            command.Parameters.AddWithValue("@password", request.Password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (reader.GetBoolean(2))
                        return JsonConvert.SerializeObject(new Request(){Success = false, FailureMessage = "User already logged in"});
                    UpdateOnlineStatus(request.Username, true);
                    return JsonConvert.SerializeObject(new Request(){Username = request.Username,Level = reader.GetInt32(1),Success = true});
                }
            }
            return JsonConvert.SerializeObject(new Request(){Success = false, FailureMessage = "Invalid username or password"});
        }
        
        public static string LoadFriends(Request request)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);

            try { 
                Connection.Open();
            }
            catch(Exception e) { Console.WriteLine(e); }

            string queryString = "SELECT user1,user2,pending FROM dbo.[Relationships]" +
                " where user1 = @username or user2 = @username;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", request.Username);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<Friend> friends = new List<Friend>();
                while (reader.Read())
                {
                    string friend_name;

                    if (reader.GetString(0) == request.Username)
                        friend_name = reader.GetString(1);
                    else
                        friend_name = reader.GetString(0);

                    var friend = GetFriend(friend_name, reader.GetBoolean(2));
                    
                    if (friend != null)
                        friends.Add(friend);
                }
                return JsonConvert.SerializeObject(new Request(){Success = true, friends = friends});
            }
        }

        public static string AddFriend(Request request)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
            }
            catch (Exception e) { Console.WriteLine(e); }

            string queryString = "SELECT pending FROM dbo.[Relationships] WHERE (user1 = @user1 AND user2 = @user2) OR (user1 = @user2 AND user2 = @user1);";
            SqlCommand selectCommand = new SqlCommand(queryString, Connection);
            selectCommand.Parameters.AddWithValue("@user1", request.Username);
            selectCommand.Parameters.AddWithValue("@user2", request.FriendUsername);

            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    bool pending = reader.GetBoolean(1);
                    if (pending)
                    {
                        string updateQueryString = "UPDATE dbo.[Relationships] SET pending = @pending WHERE (user1 = @user1 AND user2 = @user2) OR (user1 = @user2 AND user2 = @user1);";
                        SqlCommand updateCommand = new SqlCommand(updateQueryString, Connection);
                        updateCommand.Parameters.AddWithValue("@user1", request.Username);
                        updateCommand.Parameters.AddWithValue("@user2", request.FriendUsername);
                        updateCommand.Parameters.AddWithValue("@pending", 0);
                        updateCommand.ExecuteNonQuery();
                        return LoadFriends(request);
                    }
                    else
                    {
                        return JsonConvert.SerializeObject(new Request() { Success = false, FailureMessage = "Friend request already exists" });
                    }
                }
            }

            string insertQueryString = "INSERT INTO dbo.[Relationships] (user1, user2, pending, date) VALUES (@user1, @user2, @pending, @date);";
            SqlCommand insertCommand = new SqlCommand(insertQueryString, Connection);
            insertCommand.Parameters.AddWithValue("@user1", request.Username);
            insertCommand.Parameters.AddWithValue("@user2", request.FriendUsername);
            insertCommand.Parameters.AddWithValue("@pending", 1);
            insertCommand.Parameters.AddWithValue("@date", DateTime.Now);

            insertCommand.ExecuteNonQuery();
            return JsonConvert.SerializeObject(new Request() { Success = true });
        }

        public static string RemoveFriend(Request request)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
            }
            catch (Exception e) { Console.WriteLine(e); }

            string queryString = "DELETE FROM dbo.[Relationships] WHERE (user1 = @user1 AND user2 = @user2) OR (user1 = @user2 AND user2 = @user1);";
            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@user1", request.Username);
            command.Parameters.AddWithValue("@user2", request.FriendUsername);
            command.ExecuteNonQuery();
            return JsonConvert.SerializeObject(new Request() { Success = true });

        }
    }
}
