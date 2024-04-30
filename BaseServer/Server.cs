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
        private Mutex mutex;

        public void Start()
        {
            mutex = new Mutex();
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, 8080);
            _listener.Start();
            
            Console.WriteLine("Server started!");
            var thread = new Thread(() =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    HandleMessages();
                }
            });
            thread.Start();
        }

        private void HandleMessages()
        {
            var client = _listener.AcceptTcpClient(); 
            new Thread(()=> HandleClient(client)).Start();
        }

        private void HandleClient(TcpClient client)
        {
            var buffer = new byte[BufferSize];
            var stream = client.GetStream();
            var bytesRead = stream.Read(buffer, 0, buffer.Length);
            var data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            var request = JsonConvert.DeserializeObject<Request>(data);
            Console.WriteLine("Request received: " + request.Action);

            string responseMessage = ActionList.Actions[request.Action](request);
            var response = Encoding.UTF8.GetBytes(responseMessage);
            stream.Write(response, 0, response.Length);
            stream.Flush();
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