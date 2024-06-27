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
        private readonly IMapper _mapper;

        public TaskTypeService(ITaskTypeModelRepository taskTypeModelRepository, IMapper mapper, IActivityTypesService activityTypesService)
        {
            _taskTypeModelRepository = taskTypeModelRepository;
            _mapper = mapper;
            _activityTypesService = activityTypesService;
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

            return activityType;
        }

    }
}
