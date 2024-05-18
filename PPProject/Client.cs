using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace LauncherApp;

public delegate void OnDataUpdate(object sender, EventArgs args);
public class Client : IDisposable
{
    private static Client? _instance;
    private TcpClient? _tcpClient;
    private NetworkStream? _stream;
    public bool IsConnected => TcpClient!.Connected;
    public event OnDataUpdate? OnDataUpdateEvent; 


    public static Client Instance
    {
        get { return _instance ??= new Client(); }
    }
    private TcpClient? TcpClient
    {
        get { return _tcpClient??=new TcpClient(); }
        set => _tcpClient = value;
    }

    public async Task ConnectAsync(string serverIp, int serverPort)
    {
        try
        {
            await TcpClient?.ConnectAsync(serverIp,serverPort)!;
            Debug.WriteLine("Connected to server");
            _stream = TcpClient?.GetStream();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }
    public static async Task<bool> ServerAvailable()
    {
        if (!Instance.IsConnected)
        {
            await Instance.ConnectAsync("localhost", 8080);
            if (!Instance.IsConnected)
            {
                return false;
            }
        }
        Debug.WriteLine("Server is available");
        return true;
    }

    public async Task SendMessageAsync(string message)
    {
        var messageBuffer = Encoding.UTF8.GetBytes(message);
        await _stream?.WriteAsync(messageBuffer, 0, messageBuffer.Length)!;
        Debug.WriteLine("Message sent: " + message);
    }

    public async Task<string?> ReceiveMessageAsync()
    {
        var responseBuffer = new byte[20*1024*1024];
        var responseLength = await _stream?.ReadAsync(responseBuffer, 0, responseBuffer.Length)!;
        var response = Encoding.UTF8.GetString(responseBuffer, 0, responseLength);
        Debug.WriteLine("Response received: " + response);
        return response;
    }

    public async void Update()
    {
        var message = new Request() { Username = User.Instance.Username, Action = "UpdateClient" };
        await SendMessageAsync(JsonConvert.SerializeObject(message));
        var response = await ReceiveMessageAsync();
        if (response != null)
        {
            var updates = JsonConvert.DeserializeObject<Request>(response);
            User.Instance.UpdateFriends(updates?.friends!);
            if (updates != null) OnDataUpdateEvent?.Invoke(this, updates);
        }
    }

    public void Disconnect()
    {
        Dispose();
        Debug.WriteLine("Disconnected from server");
    }

    public void Dispose()
    {
        TcpClient?.Close();
        TcpClient = null;
        _stream?.Close();
        _stream = null;
        _instance = null;
    }
}