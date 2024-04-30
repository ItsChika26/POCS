using LauncherApp;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace BaseServer
{
    internal class Server
    {
        private TcpListener _listener;
        private CancellationTokenSource _cts;
        private const int BufferSize = 256;

        public void Start()
        {
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, 8080);
            _listener.Start();
            Console.WriteLine("Server started!");
            Task.Run(() => HandleMessages(_cts.Token));
        }

        private async Task HandleMessages(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var client = await _listener.AcceptTcpClientAsync(token);
                _ = HandleClient(client);
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            var buffer = new byte[BufferSize];
            var stream = client.GetStream();
            var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            var data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            var request = JsonConvert.DeserializeObject<Request>(data);
            Console.WriteLine("Request received: " + request.Action);

            string responseMessage = ActionList.Actions[request.Action](request);
            var response = Encoding.UTF8.GetBytes(responseMessage);
            await stream.WriteAsync(response, 0, response.Length);
            await stream.FlushAsync();
            Console.WriteLine("Response sent: " + responseMessage);
        }

        public void Stop()
        {
            _cts.Cancel();
            _listener.Stop();
            Console.WriteLine("Server stopped!");
        }
    }
}