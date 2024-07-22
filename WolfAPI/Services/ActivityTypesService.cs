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
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public ActivityTypesService(IActivityTypesModelRepository activityTypesModelRepository, IMapper mapper, IWebSocketService webSocketService)
        {
            _activityTypesModelRepository = activityTypesModelRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
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

        public async Task<List<GetActivityTypeDTO>> CreateActivityTypes(List<CreateActivityTypeDTO> createActivityTypeDTOs, string clientId) { 
            List<ActivityType> activityTypes = new List<ActivityType>();
            List<GetActivityTypeDTO> activityTypeDTOs = new List<GetActivityTypeDTO>();
            foreach (var acitvityTypeDto in createActivityTypeDTOs) {
                var activityType = _mapper.Map<ActivityType>(acitvityTypeDto);
                activityTypes.Add(activityType);
            }
            await _activityTypesModelRepository.AddActivityTypes(activityTypes);

            foreach(var activityType in activityTypes) {
                var activityTypeDto = _mapper.Map<GetActivityTypeDTO>(activityType);    
                activityTypeDTOs.Add(activityTypeDto);
            }

            var updateNotification = new UpdateNotification<List<GetActivityTypeDTO>>
            {
                OperationType = "Create",
                EntityType = "List<GetActivityTypeDTO>",
                UpdatedEntity = activityTypeDTOs
            };

            await _webSocketService.SendMessageToRolesAsync(updateNotification,clientId, "admin", "user");

            return activityTypeDTOs;
        }

        public async Task<GetActivityTypeDTO> GetActivityType(int id)
        {
            var ActivityType = await _activityTypesModelRepository.GetActivityType(id);
            return _mapper.Map<GetActivityTypeDTO>(ActivityType);
        }
    }
}
