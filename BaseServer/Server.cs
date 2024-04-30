using LauncherApp;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Identity.Client.NativeInterop;
using Newtonsoft.Json;

namespace BaseServer
{
    internal class Server
    {
        private TcpListener _listener;
        private CancellationTokenSource _cts;
        private const int BufferSize = 256;
        private List<TcpClient> _clients;

        public void Start()
        {
            _clients = new();
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, 8080);
            _listener.Start();
            
            Console.WriteLine("Server started!");
            Task.Run(AcceptClientsAsync, _cts.Token);
        }

        private async Task AcceptClientsAsync()
        {
            while (!_cts.Token.IsCancellationRequested)
            { 
                var client = await _listener.AcceptTcpClientAsync();
                _clients.Add(client);
                _ = Task.Run(() => ProcessRequests(client));
            }
        }

        private void BroadcastMessage(string message)
        {
            foreach (var client in _clients)
            {
                var stream = client.GetStream();
                var response = Encoding.UTF8.GetBytes(message);
                _ = stream.WriteAsync(response, 0, response.Length);
            }
        }

        private async Task ProcessRequests(TcpClient client)
        {
            while(!_cts.Token.IsCancellationRequested)
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
        }

        public void Stop()
        {
            _cts.Cancel();
            _listener.Stop();
            Console.WriteLine("Server stopped!");
        }
    }
}