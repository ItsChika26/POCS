using LauncherApp;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BaseServer
{
    internal class Server
    {
        private TcpListener _listener;
        private CancellationTokenSource _cts;
        private const int BufferSize = 20 * 1024 * 1024; // 4 MB
        public Dictionary<string, TcpClient> _clients;

        public void Start()
        {
            _clients = new();
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, 8080);
            _listener.Start();
            Database.OpenConnection();
            Console.WriteLine(@"Server started!");
            Task.Run(AcceptClientsAsync, _cts.Token);
        }

        private async Task AcceptClientsAsync()
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _ = Task.Run(() => ProcessRequests(client));
            }
        }

        private void BroadcastMessage(string message)
        {
            foreach (var client in _clients.Values)
            {
                var stream = client.GetStream();
                var response = Encoding.UTF8.GetBytes(message);
                _ = stream.WriteAsync(response, 0, response.Length);
            }
        }

        private async Task ProcessRequests(TcpClient client)
        {
            string Username = "";
            try
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    var buffer = new byte[BufferSize];
                    var stream = client.GetStream();
                    var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    var data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var request = JsonConvert.DeserializeObject<Request>(data);
                    Console.WriteLine(@"Request received: " + request!.Action);
                    Request response = await ActionList.Actions[request.Action](request)!;

                    if (request.Action == "Login" && response.Success)
                    {
                        Username = request.Username;
                        _clients.Add(request.Username, client);
                    }

                    try
                    {
                        var responseMessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
                        await stream.WriteAsync(responseMessage, 0, responseMessage.Length);
                        Console.WriteLine(@"Response sent: " + responseMessage.Length);
                    }
                    catch (JsonWriterException ex)
                    {
                        Console.WriteLine(@"Error serializing response: " + ex.Message);
                        response = new Request { Success = false, FailureMessage = "Error serializing response" };
                        var errorMessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
                        await stream.WriteAsync(errorMessage, 0, errorMessage.Length);
                    }

                    if (request.Action == "Logout" && response.Success)
                    {
                        _clients.Remove(request.Username);
                        client.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Error Processing response: " + ex.Message);
                if (Username != "")
                {
                    _clients.Remove(Username);
                    await Database.Logout(new Request() { Username = Username });
                }

                client.Close();
            }
        }

        public void Stop()
        {
            _cts.Cancel();
            _listener.Stop();
            Database.CloseConnection();
            Console.WriteLine(@"Server stopped!");
        }
    }
}