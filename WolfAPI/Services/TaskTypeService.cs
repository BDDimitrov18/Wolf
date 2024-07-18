using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.Build.Framework;
using WolfAPI.Services.Interfaces;
using DTOS.DTO;

namespace WolfAPI.Services
{
    public class TaskTypeService : ItaskTypesService
    {
        private readonly ITaskTypeModelRepository _taskTypeModelRepository;
        private readonly IActivityTypesService _activityTypesService;
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public TaskTypeService(ITaskTypeModelRepository taskTypeModelRepository, IMapper mapper, IActivityTypesService activityTypesService, IWebSocketService webSocketService)
        {
            _taskTypeModelRepository = taskTypeModelRepository;
            _mapper = mapper;
            _activityTypesService = activityTypesService;
            _webSocketService = webSocketService;
        }

        public async Task<GetActivityTypeDTO> AddTaskTypes(List<CreateTaskTypeDTO> createTaskTypesDTOs)
        {
            List<GetTaskTypeDTO> taskTypeDTOs = new List<GetTaskTypeDTO>();
            List<TaskType> taskTypes = new List<TaskType>();
            foreach(var taskTypeDTO in createTaskTypesDTOs) { 
                var taskType = _mapper.Map<TaskType>(taskTypeDTO);
                taskTypes.Add(taskType);
            }
            _taskTypeModelRepository.AddTaskTypes(taskTypes);
            foreach (var taskType in taskTypes) {
                taskTypeDTOs.Add(_mapper.Map<GetTaskTypeDTO>(taskType));
            }
            var activityType = await _activityTypesService.GetActivityType(taskTypeDTOs[0].ActivityTypeID);

            var updateNotification = new UpdateNotification<GetActivityTypeDTO>
            {
                OperationType = "Create",
                UpdatedEntity = activityType
            };
            await _webSocketService.SendMessageToAllAsync(updateNotification);

            return activityType;
        }

    }
}
