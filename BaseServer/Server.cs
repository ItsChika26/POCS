using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using LauncherApp;


namespace BaseServer
{
    internal class Server
    {
        //TCP server
        private TcpListener Listener;
        private const int BufferSize = 1024;

        private bool running = false;

        public void Start()
        {
            running = true;
            var updater = new Thread(HandleMessages);
            updater.Start();
            updater.Join();
        }

        private void HandleMessages()
        {
            Listener = new TcpListener(8080);
            Listener.Start();
            Console.WriteLine("Server started!");
            while (running)
            {
                var client = Listener.AcceptTcpClient();
                var stream = client.GetStream();

                var buffer = new byte[BufferSize];
                var bytesRead = stream.Read(buffer, 0, BufferSize);

                var data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                var request = JsonConvert.DeserializeObject<Request>(data);
                Console.WriteLine(request.Action);

                string responseMessage = ActionList.Actions[request.Action](request);

                var response = Encoding.ASCII.GetBytes(responseMessage);
                stream.Write(response, 0, response.Length);
            }

            Listener.Stop();
        }


        public void Stop()
        {
            running = false;
            Console.WriteLine("Server stopped!");
        }
    }
}