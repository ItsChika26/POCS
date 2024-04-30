using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using LauncherApp;
using System.Threading.Tasks;

namespace BaseServer
{
    internal class Server
    {
        //TCP server
        private TcpListener Listener;
        private const int BufferSize = 1024;

        public volatile bool running = false;

        public void Start()
        {
            running = true;
            Task.Run(() => HandleMessages());
        }

        private async Task HandleMessages()
        {
            Listener = new TcpListener(IPAddress.Any, 8080);
            Listener.Start();
            Console.WriteLine("Server started!");
            while (running)
            {
                var client = await Listener.AcceptTcpClientAsync();
                HandleClient(client);
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            var stream = client.GetStream();
            var buffer = new byte[BufferSize];
            var bytesRead = stream.Read(buffer, 0, BufferSize);

            var data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            var request = JsonConvert.DeserializeObject<Request>(data);
            Console.WriteLine("Request received: " + request.Action);

            string responseMessage = ActionList.Actions[request.Action](request);

            if (!stream.DataAvailable)
            {
                var response = Encoding.ASCII.GetBytes(responseMessage);
                stream.Write(response, 0, response.Length);
                Console.WriteLine("Response sent: " + responseMessage);
            }
        }


        public void Stop()
        {
            running = false;
            Console.WriteLine("Server stopped!");
        }
    }
}