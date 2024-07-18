using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IWebSocketService
    {
        Task HandleWebSocketAsync(HttpContext context);
        Task SendMessageToAllAsync<T>(UpdateNotification<T> updateNotification);
    }
}
