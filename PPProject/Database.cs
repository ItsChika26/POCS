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
        }

        public static bool RegisterUser(string username, string password)
        {
            string queryString = $"SELECT username FROM dbo.Users where username = {username};";

            SqlCommand command = new SqlCommand(queryString, Connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read()) return false;
            }

            queryString = $"INSERT INTO dbo.Users (username, password, level) VALUES ({username}, {password}, {0});";
            command = new SqlCommand(queryString, Connection);
            command.ExecuteNonQuery();
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




            static void Main(string[] args)
            {
                //in Server Explorer add connection, search for server and fill in, test - from Connection Properites read Connection String
                //if another database you can try ODBC - Computer Management -> Data Sources (ODBC) -> add User DSN
                //connetionString = @"Data Source=HOSTNAME\MINIBD;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=sastudent"; 
                connetionString = @"Server = localhost\MINIBD; Database = Northwind; User Id = sa; Password = sastudent";
                connection = new SqlConnection(connetionString);
                connection.Open();
                Console.WriteLine("Connection opened\r");

                string queryString = "SELECT firstname, lastname, birthdate FROM dbo.Employees;";
                SqlCommand command = new SqlCommand(queryString, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1} - {2}", reader[0], reader[1], reader[2]));
                    }

                }

                SqlTransaction transaction;
                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");
                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandText =
                        "Insert into Employees (firstname,lastname,birthdate) VALUES ('aaa', 'bbbb', dateadd(day,-1, getdate()) )";
                    command.ExecuteNonQuery();

                    //prepared statement - query protection
                    command.CommandText =
                        "Insert into Employees (firstname,lastname) VALUES (@first, @last)";
                    SqlParameter first = new SqlParameter("@first", SqlDbType.Text, 10);
                    SqlParameter last = new SqlParameter("@last", SqlDbType.Text, 10);
                    first.Value = "imie";
                    last.Value = "nazwisko";
                    command.Parameters.Add(first);
                    command.Parameters.Add(last);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();
                    command.ExecuteNonQuery();

                    command.Parameters[0].Value = "jeszcze";
                    command.Parameters[1].Value = "jeden";
                    // Attempt to commit the transaction.
                    command.ExecuteNonQuery();


                    transaction.Commit();
                    Console.WriteLine(
                        "Records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    //try rollback... catch ...
                }

                connection.Close();
                Console.WriteLine("Connection closed\r");
                Console.WriteLine("Press a key to close.\r");
                Console.ReadKey();
            }
    }
}
