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
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public TaskService(ItaskModelRepository taskModelRepository, IMapper mapper, IActivityModelRespository activityModelRespository, IWebSocketService webSocketService)
        {
            _taskModelRepository = taskModelRepository;
            _mapper = mapper;
            _activityModelRespository = activityModelRespository;
            _webSocketService = webSocketService;
        }

        public async Task<GetActivityDTO> CreateTask(CreateTaskDTO createTaskDTO, string clientId)
        {
            WorkTask task = _mapper.Map<WorkTask>(createTaskDTO);
            await _taskModelRepository.createTask(task);

            var activity = await _activityModelRespository.GetActivity(task.ActivityId);
            var mappedActivity = _mapper.Map<GetActivityDTO>(activity);

            var updateNotification = new UpdateNotification<GetActivityDTO>
            {
                OperationType = "Create",
                EntityType = "GetActivityDTO",
                UpdatedEntity = mappedActivity
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");

            return mappedActivity;
        }

        public async Task<bool> DeleteOnActivityAsync(Activity activity)
        {
            try
            {
                // Attempt to delete tasks related to the activity
                bool taskDeletionSuccess = await _taskModelRepository.DeleteOnActivityAsync(activity);
                if (!taskDeletionSuccess)
                {
                    // Log the failure
                    // Example: _logger.LogError($"Failed to delete tasks for activity ID {activity.ActivityId}");
                    return false;
                }

                // If the deletion was successful, return true
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                // Example: _logger.LogError(ex, $"An error occurred while deleting tasks for activity ID {activity.ActivityId}");

                // Return false to indicate failure
                return false;
            }
        }

        public async Task<bool> DeleteTasks(List<GetTaskDTO> tasksDTO, string clientId)
        {
            // Validate the input list
            if (tasksDTO == null || tasksDTO.Count == 0)
            {
                return false;
            }

            try
            {
                // Map the DTOs to WorkTask entities
                List<WorkTask> tasks = new List<WorkTask>();
                foreach (var taskDTO in tasksDTO) {
                    tasks.Add(_mapper.Map<WorkTask>(taskDTO));
                }

                var updateNotification = new UpdateNotification<List<GetTaskDTO>>
                {
                    OperationType = "Delete",
                    EntityType = "List<GetTaskDTO>",
                    UpdatedEntity = tasksDTO
                };
                await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId,"admin", "user");

                // Call the repository method to delete the tasks
                return await _taskModelRepository.DeleteTasks(tasks);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                // Handle the exception as needed
                return false;
            }
        }

        public async Task<bool> EditTask(GetTaskDTO taskDTO, string clientId) {
            bool result = await _taskModelRepository.EditTask(_mapper.Map<WorkTask>(taskDTO));

            var updateNotification = new UpdateNotification<GetTaskDTO>
            {
                OperationType = "Edit",
                EntityType = "GetTaskDTO",
                UpdatedEntity = taskDTO
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return result;
        }
    }
}
