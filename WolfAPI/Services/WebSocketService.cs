using System;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
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
    Task SendMessageToRolesAsync<T>(UpdateNotification<T> updateNotification, string initiatingClientId, params string[] roles);
}

public class WebSocketService : IWebSocketService
{
    private static ConcurrentDictionary<string, (WebSocket socket, string token, string[] roles)> _sockets = new ConcurrentDictionary<string, (WebSocket, string, string[])>();

    public async Task HandleWebSocketAsync(HttpContext context)
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            var socketId = Guid.NewGuid().ToString();

            // Extract JWT token from the request
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var clientId = GetClientIdFromJwt(token);

            // Authenticate and get user roles
            var roles = GetUserRoles(context);

            if (clientId != null && roles != null)
            {
                _sockets.TryAdd(socketId, (socket, token, roles));
                await ReceiveMessagesAsync(socket, socketId);
            }
            else
            {
                context.Response.StatusCode = 401; // Unauthorized
            }
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }

    private string GetClientIdFromJwt(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

        if (jsonToken == null)
        {
            throw new InvalidOperationException("Invalid JWT token.");
        }

        var clientIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "jti");
        if (clientIdClaim == null)
        {
            throw new InvalidOperationException("Client ID claim not found in JWT token.");
        }

        return clientIdClaim.Value;
    }

    private string[] GetUserRoles(HttpContext context)
    {
        var user = context.User;
        if (user?.Identity?.IsAuthenticated == true)
        {
            return user.Claims
                .Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
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

    public async Task SendMessageToRolesAsync<T>(UpdateNotification<T> updateNotification, string senderClientId, params string[] roles)
    {
        var message = JsonSerializer.Serialize(updateNotification);
        var buffer = Encoding.UTF8.GetBytes(message);
        var tasks = _sockets.Values
            .Where(s => s.socket.State == WebSocketState.Open && s.roles.Any(role => roles.Contains(role)) && GetClientIdFromJwt(s.token) != senderClientId)
            .Select(s => s.socket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None))
            .ToArray();
        await Task.WhenAll(tasks);
    }
}
