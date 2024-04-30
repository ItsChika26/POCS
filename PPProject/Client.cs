using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Client
{
    private static Client? instance;
    private TcpClient client;
    private NetworkStream stream;
    public bool IsConnected => client.Connected;

    public static Client Instance
    {
        get { return instance ??= new Client(); }
    }

    private Client()
    {
        client = new TcpClient();
    }

    public async Task ConnectAsync(string serverIP, int serverPort)
    {
        try
        {
            await client.ConnectAsync(serverIP, serverPort);
            Debug.WriteLine("Connected to server");
            stream = client.GetStream();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }

    public async Task SendMessageAsync(string message)
    {
        var buffer = Encoding.UTF8.GetBytes(message);
        await stream.WriteAsync(buffer, 0, buffer.Length);
        await stream.FlushAsync();
        Debug.WriteLine("Message sent: " + message);
    }

    public async Task<string?> ReceiveMessageAsync()
    {
        var responseBuffer = new byte[1024];
        var responseLength = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
        var response = Encoding.UTF8.GetString(responseBuffer, 0, responseLength);
        Debug.WriteLine("Response received: " + response);
        return response;
    }

    public void Disconnect()
    {
        stream.Close();
        client.Close();
        Debug.WriteLine("Disconnected from server");
    }
}