using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IActivityTypesService
    {
        public List<GetActivityTypeDTO> GetAll();

        public Task<List<GetActivityTypeDTO>> CreateActivityTypes(List<CreateActivityTypeDTO> createActivityTypeDTOs, string clientId);

        public Task<GetActivityTypeDTO> GetActivityType(int id);

    }
}
