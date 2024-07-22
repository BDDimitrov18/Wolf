using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface ItaskTypesService
    {
        public Task<GetActivityTypeDTO> AddTaskTypes(List<CreateTaskTypeDTO> createTaskTypesDTOs, string clientId);
    }
}
