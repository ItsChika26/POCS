namespace BaseServer
{
    internal class Program
    {
        static void Main()
        {
            Server server = new Server();
            Database.Connect();
            server.Start();
        }
    }
}
