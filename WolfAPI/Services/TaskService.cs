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
        private readonly IMapper _mapper;

        public TaskService(ItaskModelRepository taskModelRepository, IMapper mapper)
        {
            _taskModelRepository = taskModelRepository;
            _mapper = mapper;
        }
        
        public async Task<GetActivityDTO> CreateTask(CreateTaskDTO createTaskDTO)
        {
            WorkTask task = _mapper.Map<WorkTask>(createTaskDTO); 
            await _taskModelRepository.createTask(task);
            return _mapper.Map<GetActivityDTO>(task.Activity);
        }
    }
}
