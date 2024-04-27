using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
            Listener = new TcpListener(IPAddress.Any, 8000);
            Listener.Start();
            Console.WriteLine("Server started!");
            while (running)
            {
                var client = Listener.AcceptTcpClient();
                var stream = client.GetStream();

                var buffer = new byte[BufferSize];
                var bytesRead = stream.Read(buffer, 0, BufferSize);

                var data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {data}");



                var response = Encoding.ASCII.GetBytes(data);
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
