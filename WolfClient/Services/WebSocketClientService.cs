using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class WebSocketClientService
{
    private readonly ClientWebSocket _client;
    private readonly Uri _serverUri;
    private string _token;
    private CancellationTokenSource _cancellationTokenSource;

    public event Action<string> OnMessageReceived;

    public WebSocketClientService(string serverUrl)
    {
        _client = new ClientWebSocket();
        _serverUri = new Uri(serverUrl);
    }

    public void SetToken(string token)
    {
        _token = token;
    }

    public async Task ConnectAsync()
    {
        if (string.IsNullOrEmpty(_token))
        {
            throw new InvalidOperationException("Token must be set before connecting.");
        }

        _cancellationTokenSource = new CancellationTokenSource();
        _client.Options.SetRequestHeader("Authorization", $"Bearer {_token}");
        await _client.ConnectAsync(_serverUri, _cancellationTokenSource.Token);
        await ReceiveMessagesAsync(_cancellationTokenSource.Token);
    }

    public async Task DisconnectAsync()
    {
        _cancellationTokenSource.Cancel();
        await _client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
    }

    private async Task ReceiveMessagesAsync(CancellationToken cancellationToken)
    {
        var buffer = new byte[1024 * 4];
        while (_client.State == WebSocketState.Open)
        {
            try
            {
                var result = await _client.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    OnMessageReceived?.Invoke(message);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation
            }
        }
    }

    public async Task SendMessageAsync(string message)
    {
        var buffer = Encoding.UTF8.GetBytes(message);
        await _client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
    }
}
