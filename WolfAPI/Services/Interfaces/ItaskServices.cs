using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface ItaskServices
    {
        public Task<GetActivityDTO> CreateTask(CreateTaskDTO createTaskDTO);
        public Task<bool> DeleteOnActivityAsync(Activity activity);

        public Task<bool> DeleteTasks(List<GetTaskDTO> tasks);
    }
}
