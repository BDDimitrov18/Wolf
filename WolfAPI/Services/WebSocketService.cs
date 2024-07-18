using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DTOS.DTO;
using Microsoft.AspNetCore.Http;

public interface IWebSocketService
{
    Task HandleWebSocketAsync(HttpContext context);
    Task SendMessageToRolesAsync<T>(UpdateNotification<T> updateNotification, params string[] roles);
}

public class WebSocketService : IWebSocketService
{
    private static ConcurrentDictionary<string, (WebSocket socket, string[] roles)> _sockets = new ConcurrentDictionary<string, (WebSocket, string[])>();

    public async Task HandleWebSocketAsync(HttpContext context)
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            var socketId = Guid.NewGuid().ToString();

            // Authenticate and get user roles
            var roles = GetUserRoles(context); // Implement this method to get user roles based on your authentication mechanism

            _sockets.TryAdd(socketId, (socket, roles));

            await ReceiveMessagesAsync(socket, socketId);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }

    private string[] GetUserRoles(HttpContext context)
    {
        // Implement role extraction logic based on your authentication mechanism
        var user = context.User;
        if (user?.Identity?.IsAuthenticated == true)
        {
            return user.Claims
                .Where(c => c.Type == "role")
                .Select(c => c.Value)
                .ToArray();
        }

        return Array.Empty<string>();
    }

    private static async Task ReceiveMessagesAsync(WebSocket socket, string socketId)
    {
        var buffer = new byte[1024 * 4];
        WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!result.CloseStatus.HasValue)
        {
            result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        _sockets.TryRemove(socketId, out var _);
        await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
    }

    public async Task SendMessageToRolesAsync<T>(UpdateNotification<T> updateNotification, params string[] roles)
    {
        var message = JsonSerializer.Serialize(updateNotification);
        var buffer = Encoding.UTF8.GetBytes(message);
        var tasks = _sockets.Values
            .Where(s => s.socket.State == WebSocketState.Open && s.roles.Any(role => roles.Contains(role)))
            .Select(s => s.socket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None))
            .ToArray();
        await Task.WhenAll(tasks);
    }
}
