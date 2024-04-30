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
        private const int BufferSize = 256;

        public volatile bool running = false;

        public void Start()
        {
            running = true;
            Task.Run(HandleMessages);
        }

        private async Task HandleMessages()
        {
            Listener = new TcpListener(IPAddress.Any, 8080);
            Listener.Start();
            Console.WriteLine("Server started!");
            while (running)
            {
                var client = await Listener.AcceptTcpClientAsync();
                _ = Task.Run(() => HandleClient(client));
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            var buffer = new char[BufferSize];
            int bytesRead = 0;
            using (StreamReader stream = new StreamReader(client.GetStream())) { 
                bytesRead = await stream.ReadAsync(buffer, 0, BufferSize);
            }
            var data = new string(buffer, 0, bytesRead);
            var request = JsonConvert.DeserializeObject<Request>(data);
            Console.WriteLine("Request received: " + request.Action);


            string responseMessage = ActionList.Actions[request.Action](request);
            var response = responseMessage.ToCharArray(); 
            await using (StreamWriter stream = new StreamWriter(client.GetStream())){ 
                await stream.WriteAsync(response, 0, response.Length); 
                _ = stream.FlushAsync();
            }
            Console.WriteLine("Response sent: " + responseMessage);
        }


        public void Stop()
        {
            running = false;
            Console.WriteLine("Server stopped!");
        }
    }
}