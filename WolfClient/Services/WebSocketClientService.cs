using System;
using System.Net.Security;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WolfClient.Services.Interfaces;

public class WebSocketClientService
{
    private ClientWebSocket _client;
    private readonly Uri _serverUri;
    private string _token;
    private CancellationTokenSource _cancellationTokenSource;
    private readonly IDataService _dataService;

    public WebSocketClientService(string serverUrl, IDataService dataService)
    {
        _client = new ClientWebSocket();
        _serverUri = new Uri(serverUrl);
        _dataService = dataService;

        // Bypass SSL certificate validation for self-signed certificates
        _client.Options.RemoteCertificateValidationCallback = ValidateServerCertificate;
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

        try
        {
            await _client.ConnectAsync(_serverUri, _cancellationTokenSource.Token);
            await ReceiveMessagesAsync(_cancellationTokenSource.Token);
        }
        catch (WebSocketException ex)
        {
            Console.WriteLine($"WebSocketException: {ex.Message}");
            await ReconnectAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Always accept the certificate (ignore SSL validation errors)
        return true;
    }

    private async Task ReconnectAsync()
    {
        int retryCount = 0;
        const int maxRetries = 5;
        const int delayBetweenRetries = 5000; // 5 seconds

        while (retryCount < maxRetries && _client.State != WebSocketState.Open)
        {
            retryCount++;
            Console.WriteLine($"Attempt {retryCount} to reconnect...");
            await Task.Delay(delayBetweenRetries);

            _client = new ClientWebSocket();
            _client.Options.SetRequestHeader("Authorization", $"Bearer {_token}");
            _client.Options.RemoteCertificateValidationCallback = ValidateServerCertificate; // Add the callback again

            try
            {
                await _client.ConnectAsync(_serverUri, _cancellationTokenSource.Token);
                await ReceiveMessagesAsync(_cancellationTokenSource.Token);
            }
            catch (WebSocketException ex)
            {
                Console.WriteLine($"WebSocketException on retry {retryCount}: {ex.Message}");
            }
        }

        if (_client.State != WebSocketState.Open)
        {
            Console.WriteLine("Failed to reconnect after multiple attempts.");
        }
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
            catch (WebSocketException ex)
            {
                Console.WriteLine($"WebSocketException: {ex.Message}");
                await ReconnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
