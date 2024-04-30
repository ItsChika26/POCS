﻿using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Client
{
    private static Client? instance;
    private TcpClient client;
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
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }

    public async Task<string?> SendMessage(string message)
    {
        await using var stream = client.GetStream();
        try
        {
            var data = Encoding.ASCII.GetBytes(message);
            if (!stream.DataAvailable)
            {
                await stream.WriteAsync(data, 0, data.Length);
                Debug.WriteLine("Message sent: " + message);
            }

            data = new byte[256];
            var response = string.Empty;
            var bytes = await stream.ReadAsync(data, 0, data.Length);
            response = Encoding.ASCII.GetString(data, 0, bytes);
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