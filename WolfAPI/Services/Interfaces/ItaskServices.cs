using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface ItaskServices
    {
        public Task<GetActivityDTO> CreateTask(CreateTaskDTO createTaskDTO);
    }
}
