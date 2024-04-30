using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Client
{

    private static Client instance = null;
    private static readonly object padlock = new object();
     
    private TcpClient client;
    private NetworkStream stream;
    Client()
    {
    }

    public static Client Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }
    }

    public bool IsConnected()
    {
        return client == null ? false : client.Connected;
    }
    public async Task<bool> Connect(string serverIP, int serverPort)
    {
        try
        {
            client = new TcpClient();
            await client.ConnectAsync(serverIP, serverPort);
            stream = client.GetStream();
            return true;
        }
        catch (SocketException)
        {
            client.Close();
            return false;
        }
    }

    public async Task<string?> SendMessage(string message)
    {
        var data = Encoding.ASCII.GetBytes(message);
        await stream.WriteAsync(data, 0, data.Length);

        data = new byte[256];
        var response = string.Empty;
        var bytes = await stream.ReadAsync(data, 0, data.Length);
        response = Encoding.ASCII.GetString(data, 0, bytes);
        return response;
    }

    public void Disconnect()
    {
        stream.Close();
        client.Close();
    }
}