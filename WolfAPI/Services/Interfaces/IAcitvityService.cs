using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IAcitvityService
    {
        public Task<GetActivityDTO> CreateActivitiy(CreateActivityDTO createActivityDTO);
    }
}
