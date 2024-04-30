using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Client
{

    private static Client? instance;
    private static readonly object padlock = new object();

    private TcpClient client;
    private NetworkStream stream;
    public bool IsConnected => client.Connected;

    public static Client Instance
    {
        get
        {
            lock (padlock)
            {
                return instance ??= new Client();
            }
        }
    }

    private Client()
    {
        client = new TcpClient();
    }

    public void Connect(string serverIP, int serverPort)
    {
        try
        {
            client.Connect(serverIP, serverPort);
            stream = client.GetStream();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
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