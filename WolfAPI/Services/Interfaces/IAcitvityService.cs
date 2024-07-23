using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IAcitvityService
    {
        public Task<GetActivityDTO> CreateActivitiy(CreateActivityDTO createActivityDTO);

        public Task<bool> DeleteOnRequest(Request request);
        public Task<bool> DeleteActivities(List<GetActivityDTO> activityDTOs, string clientId);

        public Task<bool> EditActivity(GetActivityDTO activityDTO);
    }
}
