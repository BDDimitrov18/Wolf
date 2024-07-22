using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static class WebSocketHandler
{
    public static async Task Handle(HttpContext context, IWebSocketService webSocketService)
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            await webSocketService.HandleWebSocketAsync(context);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }
}
