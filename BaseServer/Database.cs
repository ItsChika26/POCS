using LauncherApp;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace BaseServer
{
    internal static class Database
    {
        private static string ConnectionString =
            "Data Source=AMMURA-LAPTOP;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private static SqlConnection Connection = new(ConnectionString);

        public static void OpenConnection()
        {
            Connection.Open();
        }

        public static Friend? GetFriend(string username, bool pending, bool isReqOwner, DateTime date)
        {
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
                    var friend = new Friend(friend_name, level, online, pending, isReqOwner, date);
                    return friend;
                }
            }
            return null;
        }
        public static string RegisterUser(Request request)
        {
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

        public static void RebuildDatabase()
        {
            try
            {
                    string script = File.ReadAllText("builddatabase.sql");

                    // Execute the script against the database
                    using (SqlCommand sqlCommand = new SqlCommand(script, Connection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    Console.WriteLine("Database rebuilt successfully.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while rebuilding the database: " + ex.Message);
            }
        }

        public static string UpdateOnlineStatus(string username, int status)
        {
            string queryString = "UPDATE dbo.[Users] SET Online = @online WHERE username = @username;";
            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@online", status);
            command.ExecuteNonQuery();
            return JsonConvert.SerializeObject(new Request(){Success = true});
        }
        public static string Logout(Request request)
        {
            UpdateOnlineStatus(request.Username, 0);
            return JsonConvert.SerializeObject(new Request(){Success = true});
        }

        public static string LoginUser(Request request)
        {
            string queryString = "SELECT username, level,Online FROM dbo.[Users] where username = @username and password = @password;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", request.Username);
            command.Parameters.AddWithValue("@password", request.Password);
            bool found = false;
            int level = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    found = true;
                    level = reader.GetInt32(1);

                    if (reader.GetBoolean(2))
                        return JsonConvert.SerializeObject(new Request(){Success = false, FailureMessage = "User already logged in"});
                }
            } 
            if(!found) 
                return JsonConvert.SerializeObject(new Request(){Success = false, FailureMessage = "Invalid username or password"});
            UpdateOnlineStatus(request.Username, 1);
            return JsonConvert.SerializeObject(new Request(){Username = request.Username,Level = level,Success = true});
        }

        public static string UpdateClient(Request request)
        {
            var allUpdates = new Request();

            var friendsRequest = LoadFriends(request);
            allUpdates.friends = JsonConvert.DeserializeObject<Request>(friendsRequest)!.friends;

            allUpdates.Success = true;
            return JsonConvert.SerializeObject(allUpdates);

        }
        
        public static string LoadFriends(Request request)
        {
            string queryString = "SELECT user1,user2,pending,Date FROM dbo.[Relationships]" +
                " where user1 = @username or user2 = @username;";

            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@username", request.Username);

            List<(string,bool,bool,DateTime)> friends = new();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string friend_name;
                    bool isReqOwner = false;
                    var date = reader.GetDateTime(3);

                    if (reader.GetString(0) == request.Username)
                        friend_name = reader.GetString(1);
                    else
                    {
                        friend_name = reader.GetString(0); 
                        isReqOwner = true;
                    }
                    friends.Add(new (friend_name,reader.GetBoolean(2),isReqOwner,date));
                }
            }
            List<Friend> friendsList = new();

            foreach (var friend in friends)
            {
                Friend? friendObj = GetFriend(friend.Item1,friend.Item2, friend.Item3, friend.Item4);
                if (friendObj != null)
                    friendsList.Add(friendObj);
            }
            return JsonConvert.SerializeObject(new Request(){Success = true, friends = friendsList});
        }

        public static string AddFriend(Request request)
        {
            string queryString = "SELECT pending FROM dbo.[Relationships] WHERE (user1 = @user1 AND user2 = @user2) OR (user1 = @user2 AND user2 = @user1);";
            SqlCommand selectCommand = new SqlCommand(queryString, Connection);
            selectCommand.Parameters.AddWithValue("@user1", request.Username);
            selectCommand.Parameters.AddWithValue("@user2", request.FriendUsername);
            bool pending = false;
            bool exists = false;
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    exists = true;
                    pending = reader.GetBoolean(0);
                    
                }
            }
            if (pending && exists)
            {
                string updateQueryString = "UPDATE dbo.[Relationships] SET pending = @pending WHERE (user1 = @user1 AND user2 = @user2) OR (user1 = @user2 AND user2 = @user1);";
                SqlCommand updateCommand = new SqlCommand(updateQueryString, Connection);
                updateCommand.Parameters.AddWithValue("@user1", request.Username);
                updateCommand.Parameters.AddWithValue("@user2", request.FriendUsername);
                updateCommand.Parameters.AddWithValue("@pending", 0);
                updateCommand.ExecuteNonQuery();
                return LoadFriends(request);
            }
            else if (exists)
            {
                return JsonConvert.SerializeObject(new Request() { Success = false, FailureMessage = "Friend request already exists" });
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
            string queryString = "DELETE FROM dbo.[Relationships] WHERE (user1 = @user1 AND user2 = @user2) OR (user1 = @user2 AND user2 = @user1);";
            SqlCommand command = new SqlCommand(queryString, Connection);
            command.Parameters.AddWithValue("@user1", request.Username);
            command.Parameters.AddWithValue("@user2", request.FriendUsername);
            command.ExecuteNonQuery();
            return JsonConvert.SerializeObject(new Request() { Success = true });
        }
        public static void CloseConnection()
        {
            Connection.Close();
        }
    }
}
