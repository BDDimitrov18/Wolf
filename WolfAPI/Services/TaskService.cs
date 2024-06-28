using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class TaskService: ItaskServices
    {
        private readonly ItaskModelRepository _taskModelRepository;
        private readonly IActivityModelRespository _activityModelRespository;
        private readonly IMapper _mapper;

        public TaskService(ItaskModelRepository taskModelRepository, IMapper mapper, IActivityModelRespository activityModelRespository)
        {
            _taskModelRepository = taskModelRepository;
            _mapper = mapper;
            _activityModelRespository = activityModelRespository;
        }
        
        public async Task<GetActivityDTO> CreateTask(CreateTaskDTO createTaskDTO)
        {
            WorkTask task = _mapper.Map<WorkTask>(createTaskDTO); 
            await _taskModelRepository.createTask(task);

            var activity = await _activityModelRespository.GetActivity(task.ActivityId);
            var mappedActivity = _mapper.Map<GetActivityDTO>(activity);
            return mappedActivity;
        }
    }
}
