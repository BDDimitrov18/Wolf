using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WolfClient.Services.Interfaces;

public class WebSocketClientService : IDisposable
{
    private readonly ClientWebSocket _client;
    private readonly Uri _serverUri;
    private string _token;
    private CancellationTokenSource _cancellationTokenSource;
    private readonly IDataService _dataService;

    public WebSocketClientService(string serverUrl, IDataService dataService)
    {
        _client = new ClientWebSocket();
        _serverUri = new Uri(serverUrl);
        _dataService = dataService;
    }

    public async void SetToken(string token)
    {
        _token = token;
        await ConnectAsync();
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
                    _dataService.HandleWebSocketMessage(message);
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
    public void Dispose()
    {
        Task.Run(DisconnectAsync).Wait();
        _client.Dispose();
    }
}
