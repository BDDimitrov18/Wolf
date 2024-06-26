using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class ActivityTypesService : IActivityTypesService
    {
        private readonly IActivityTypesModelRepository _activityTypesModelRepository;
        private readonly IMapper _mapper;

        public ActivityTypesService(IActivityTypesModelRepository activityTypesModelRepository, IMapper mapper)
        {
            _activityTypesModelRepository = activityTypesModelRepository;
            _mapper = mapper;
        }

        public List<GetActivityTypeDTO> GetAll() { 
            List<ActivityType> activityTypes = _activityTypesModelRepository.GetAllActivityTypes();
            List<GetActivityTypeDTO> returnList = new List<GetActivityTypeDTO>();
            foreach (ActivityType activityType in activityTypes) {
                var activityTypeDTO = _mapper.Map<GetActivityTypeDTO>(activityType);
                returnList.Add(activityTypeDTO);
            }
            return returnList;
        }

        public List<GetActivityTypeDTO> CreateActivityTypes(List<CreateActivityTypeDTO> createActivityTypeDTOs) { 
            List<ActivityType> activityTypes = new List<ActivityType>();
            List<GetActivityTypeDTO> activityTypeDTOs = new List<GetActivityTypeDTO>();
            foreach (var acitvityTypeDto in createActivityTypeDTOs) {
                var activityType = _mapper.Map<ActivityType>(acitvityTypeDto);
                activityTypes.Add(activityType);
            }
            _activityTypesModelRepository.AddActivityTypes(activityTypes);

            foreach(var activityType in activityTypes) {
                var activityTypeDto = _mapper.Map<GetActivityTypeDTO>(activityType);    
                activityTypeDTOs.Add(activityTypeDto);
            }
            return activityTypeDTOs;
        }
    }
}
