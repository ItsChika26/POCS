namespace BaseServer
{
    internal class Program
    {
        static void Main()
        {
            Server server = new Server();
            server.Start();
            string command;
            Console.WriteLine("Type 'stop' to stop the server, 'restart' to restart the server or 'exit' to exit the program");
            while ((command = Console.ReadLine()) != "exit")
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
            }
        }
    }
}
