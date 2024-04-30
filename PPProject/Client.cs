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

    public void Connect(string serverIP, int serverPort)
    {
        try
        {
            client.Connect(serverIP, serverPort);
            Debug.WriteLine("Connected to server");
            stream = client.GetStream();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }

    public async Task<string?> SendMessage(string message)
    {
        try
        {
            var data = message.ToCharArray();
            await using (StreamWriter writer = new StreamWriter(stream)){ 
                await writer.WriteAsync(data); 
                await writer.FlushAsync();
            }
            Debug.WriteLine("Message sent: " + message);

            
            var response = string.Empty;
            using (StreamReader reader = new StreamReader(stream))
            {
                response = await reader.ReadToEndAsync();
            }
            Debug.WriteLine("Response received: " + response);
            return response;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null;
        }
    }
}