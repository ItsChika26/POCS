using LauncherApp;
namespace BaseServer
{
    internal class Program
    {
        static void Main()
        {
            Server server = new Server();
            server.Start();
            string command;
            Console.WriteLine(@"Type 'stop' to stop the server, 'restart' to restart the server," +
                              @" 'rebuild' to rebuild the database, \n" +
                              @"logout user to logout a user" +
                              @" or 'exit' to exit the program");
            while ((command = Console.ReadLine()!) != "exit")
            {
                if (command == "stop")
                {
                    server.Stop();
                }
                else if (command == "restart")
                {
                    server.Stop();
                    server.Start();
                }
                else if (command == "rebuild")
                {
                    Database.RebuildDatabase();
                }
                else if (command!.StartsWith("logout"))
                {
                    string[] split = command.Split(' ');
                    if (split.Length == 2)
                    {
                        Database.Logout(new Request() { Username = split[1] });
                        if(server._clients.ContainsKey(split[1]))
                        {
                            server._clients[split[1]].Close();
                            if (server._clients.Remove(split[1]))
                                Console.WriteLine($@"{split[1]} logged out");
                        }
                        else
                        {
                            Console.WriteLine($@"{split[1]} is not logged in");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}
