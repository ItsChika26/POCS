using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;
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

        public static async Task OpenConnection()
        {
            await Connection.OpenAsync();
        }

        public static async Task<Friend?> GetFriend(string username, bool pending, bool isReqOwner, DateTime date)
        {
            try
            {
                string queryString = "SELECT username, level,Online,Image FROM dbo.[Users] where username = @username;";
                SqlCommand command = new SqlCommand(queryString, Connection);
                command.Parameters.AddWithValue("@username", username);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var friend_name = reader.GetString(0);
                        var level = reader.GetInt32(1);
                        var online = reader.GetBoolean(2);
                        byte[] imageBytes = null;
                        if (!reader.IsDBNull(3)) // Check if the image column is not null
                        {
                            imageBytes = (byte[])reader.GetValue(3); // Retrieve the image as byte array
                        }
                        var image = imageBytes;
                        var friend = new Friend(friend_name, level, online, pending, isReqOwner, date, image);
                        return friend;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the GetFriend query: " + ex.Message);
            }
            return null;
        }

        public async static Task<Request> UpdateIcon(Request request)
        {
            try
            {
                string queryString = "UPDATE dbo.[Users] SET Image = @icon WHERE username = @username;";
                SqlCommand command = new SqlCommand(queryString, Connection);
                command.Parameters.AddWithValue("@username", request.Username);
                command.Parameters.AddWithValue("@icon", request.Image);
                await command.ExecuteNonQueryAsync();
                return new Request() { Success = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the UpdateIcon query: " + ex.Message);
            }
            return null;
        }

        public static async Task<Request> RegisterUser(Request request)
        {
            try
            {
                string queryString = "SELECT username FROM dbo.[Users] where username = @username;";

                SqlCommand command = new SqlCommand(queryString, Connection);
                command.Parameters.AddWithValue("@username", request.Username);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        return new Request() { Success = false, FailureMessage = "User already exists" };
                }

                queryString =
                    "INSERT INTO dbo.[Users] (username, password, level, date_registered, XP, Image) VALUES (@username, @password, @level, @date_registered, @XP, @image);";
                SqlCommand insertCommand = new SqlCommand(queryString, Connection);
                insertCommand.Parameters.AddWithValue("@username", request.Username);
                insertCommand.Parameters.AddWithValue("@password", request.Password);
                insertCommand.Parameters.AddWithValue("@level", 0);
                insertCommand.Parameters.AddWithValue("@date_registered", DateTime.Now);
                insertCommand.Parameters.AddWithValue("@XP", 0);

                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync("https://avatar.iran.liara.run/public");
                    insertCommand.Parameters.AddWithValue("@image", imageBytes);
                }

                await insertCommand.ExecuteNonQueryAsync();
                return new Request() { Success = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the RegisterUser query: " + ex.Message);
            }
            return null;
        }

        public static async Task RebuildDatabase()
        {
            try
            {
                string script = File.ReadAllText("builddatabase.sql");

                // Execute the script against the database
                using (SqlCommand sqlCommand = new SqlCommand(script, Connection))
                {
                    await sqlCommand.ExecuteNonQueryAsync();
                }

                Console.WriteLine("Database rebuilt successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while rebuilding the database: " + ex.Message);
            }
        }

        public static async Task<Request> UpdateOnlineStatus(string username, int status)
        {
            try
            {
                string queryString = "UPDATE dbo.[Users] SET Online = @online WHERE username = @username;";
                SqlCommand command = new SqlCommand(queryString, Connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@online", status);
                await command.ExecuteNonQueryAsync();
                return new Request() { Success = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the UpdateOnlineStatus query: " + ex.Message);
            }
            return null;
        }

        public static async Task<Request> Logout(Request request)
        {
            try
            {
                await UpdateOnlineStatus(request.Username, 0);
                return new Request() { Success = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the Logout query: " + ex.Message);
            }
            return null;
        }

        public static async Task<Request> LoginUser(Request request)
        {
            try
            {
                string queryString = "SELECT username, level, Online, Image FROM dbo.[Users] WHERE username = @username AND password = @password;";

                SqlCommand command = new SqlCommand(queryString, Connection);
                command.Parameters.AddWithValue("@username", request.Username);
                command.Parameters.AddWithValue("@password", request.Password);
                bool found = false;
                int level = 0;
                byte[] imageBytes = null; // Variable to store the image as byte array

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        found = true;
                        level = reader.GetInt32(1);
                        if (!reader.IsDBNull(3)) // Check if the image column is not null
                        {
                            imageBytes = (byte[])reader.GetValue(3); // Retrieve the image as byte array
                        }
                        if (reader.GetBoolean(2))
                            return new Request() { Success = false, FailureMessage = "User already logged in" };
                    }
                }

                if (!found)
                    return new Request() { Success = false, FailureMessage = "Invalid username or password" };

                await UpdateOnlineStatus(request.Username, 1);

                var response = new Request()
                {
                    Username = request.Username,
                    Level = level,
                    Image = imageBytes,
                    Success = true
                };

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the LoginUser query: " + ex.Message);
            }
            return null;
        }

        public static async Task<Request> UpdateClient(Request request)
        {
            try
            {
                var allUpdates = new Request();

                var friendsRequest = await LoadFriends(request);
                allUpdates.friends = friendsRequest.friends;

                allUpdates.Success = true;
                return allUpdates;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the UpdateClient query: " + ex.Message);
            }
            return null;
        }

        public static async Task<Request> LoadFriends(Request request)
        {
            try
            {
                string queryString = "SELECT user1,user2,pending,Date FROM dbo.[Relationships]" +
                    " where user1 = @username or user2 = @username;";

                SqlCommand command = new SqlCommand(queryString, Connection);
                command.Parameters.AddWithValue("@username", request.Username);

                List<(string, bool, bool, DateTime)> friends = new();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
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
                        friends.Add(new(friend_name, reader.GetBoolean(2), isReqOwner, date));
                    }
                }
                List<Friend> friendsList = new();

                foreach (var friend in friends)
                {
                    Friend? friendObj = await GetFriend(friend.Item1, friend.Item2, friend.Item3, friend.Item4);
                    if (friendObj != null)
                        friendsList.Add(friendObj);
                }
                return new Request() { Success = true, friends = friendsList };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the LoadFriends query: " + ex.Message);
            }
            return null;
        }

        public static async Task<Request> AddFriend(Request request)
        {
            try
            {
                string queryString = "SELECT pending FROM dbo.[Relationships] WHERE (user1 = @user1 AND user2 = @user2) OR (user1 = @user2 AND user2 = @user1);";
                SqlCommand selectCommand = new SqlCommand(queryString, Connection);
                selectCommand.Parameters.AddWithValue("@user1", request.Username);
                selectCommand.Parameters.AddWithValue("@user2", request.FriendUsername);
                bool pending = false;
                bool exists = false;
                using (SqlDataReader reader = await selectCommand.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
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
                    await updateCommand.ExecuteNonQueryAsync();
                    return await LoadFriends(request);
                }
                else if (exists)
                {
                    return new Request() { Success = false, FailureMessage = "Friend request already exists" };
                }

                string insertQueryString = "INSERT INTO dbo.[Relationships] (user1, user2, pending, date) VALUES (@user1, @user2, @pending, @date);";
                SqlCommand insertCommand = new SqlCommand(insertQueryString, Connection);
                insertCommand.Parameters.AddWithValue("@user1", request.Username);
                insertCommand.Parameters.AddWithValue("@user2", request.FriendUsername);
                insertCommand.Parameters.AddWithValue("@pending", 1);
                insertCommand.Parameters.AddWithValue("@date", DateTime.Now);

                await insertCommand.ExecuteNonQueryAsync();
                return new Request() { Success = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the AddFriend query: " + ex.Message);
            }
            return null;
        }

        public static async Task<Request> RemoveFriend(Request request)
        {
            try
            {
                string queryString = "DELETE FROM dbo.[Relationships] WHERE (user1 = @user1 AND user2 = @user2) OR (user1 = @user2 AND user2 = @user1);";
                SqlCommand command = new SqlCommand(queryString, Connection);
                command.Parameters.AddWithValue("@user1", request.Username);
                command.Parameters.AddWithValue("@user2", request.FriendUsername);
                await command.ExecuteNonQueryAsync();
                return new Request() { Success = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while executing the RemoveFriend query: " + ex.Message);
            }
            return null;
        }

        public static void CloseConnection()
        {
            Connection.Close();
        }
    }
}
