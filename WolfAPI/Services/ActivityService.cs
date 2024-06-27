using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class ActivityService : IAcitvityService
    {
        private readonly IActivityModelRespository _activityModelRespository;
        private readonly IMapper _mapper;

        public ActivityService(IActivityModelRespository activityModelRespository, IMapper mapper)
        {
            _activityModelRespository = activityModelRespository;
            _mapper = mapper;
        }

        public async Task<GetActivityDTO> CreateActivitiy(CreateActivityDTO createActivityDTO) {
            Activity activity = _mapper.Map<Activity>(createActivityDTO);
            await _activityModelRespository.CreateActivity(activity);
            var activityDTO = _mapper.Map<GetActivityDTO>(activity);
            return activityDTO;
        }
    }
}
