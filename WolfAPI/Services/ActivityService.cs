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
        private readonly ItaskModelRepository _taskModelRepository;
        private readonly IActivity_PlotReleashionshipService _activity_plotReleashionshipService;
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public ActivityService(IActivityModelRespository activityModelRespository, IMapper mapper, ItaskModelRepository taskModelRepository,
        IActivity_PlotReleashionshipService activity_plotReleashionshipService, IWebSocketService webSocketService)
        {
            _activityModelRespository = activityModelRespository;
            _mapper = mapper;
            _taskModelRepository = taskModelRepository;
            _activity_plotReleashionshipService = activity_plotReleashionshipService;
            _webSocketService = webSocketService;
        }

        public async Task<GetActivityDTO> CreateActivitiy(CreateActivityDTO createActivityDTO) {
            Activity activity = _mapper.Map<Activity>(createActivityDTO);
            await _activityModelRespository.CreateActivity(activity);
            var activityDTO = _mapper.Map<GetActivityDTO>(activity);
            return activityDTO;
        }

        public async Task<bool> DeleteOnRequest(Request request)
        {
            try
            {
                // Find the activities linked to the request
                var activities = _activityModelRespository.FindLinkedActivity(request);
                bool allDeletionsSuccessful = true;

                foreach (var activity in activities)
                {
                    // Delete activity plot relationships for the activity
                    bool activityPlotDeletionSuccess = await _activity_plotReleashionshipService.OnActivityDelete(activity);
                    if (!activityPlotDeletionSuccess)
                    {
                        // Log the failure
                        // Example: _logger.LogError($"Failed to delete activity plot relationships for activity ID {activity.ActivityId}");
                        allDeletionsSuccessful = false;
                    }

                    // Delete tasks for the activity
                    bool taskDeletionSuccess = await _taskModelRepository.DeleteOnActivityAsync(activity);
                    if (!taskDeletionSuccess)
                    {
                        // Log the failure
                        // Example: _logger.LogError($"Failed to delete tasks for activity ID {activity.ActivityId}");
                        allDeletionsSuccessful = false;
                    }
                }

                // Delete activities related to the request
                List<Activity> activitiesAllToDelete = new List<Activity>();
                List<GetActivityDTO> activityDTOs = new List<GetActivityDTO>();
                bool activityDeletionSuccess = await _activityModelRespository.DeleteOnRequestAsync(request, activitiesAllToDelete);
                if (!activityDeletionSuccess)
                {
                    // Log the failure
                    // Example: _logger.LogError($"Failed to delete activities for request ID {request.RequestId}");
                    allDeletionsSuccessful = false;
                }
                

                return allDeletionsSuccessful;
            }
            catch (Exception ex)
            {
                // Log the exception
                // Example: _logger.LogError(ex, "An error occurred while deleting on request");

                // Return false to indicate failure
                return false;
            }
        }

        public async Task<bool> DeleteActivities(List<GetActivityDTO> activityDTOs, string clientId)
        {
            // Validate the input list
            if (activityDTOs == null || activityDTOs.Count == 0)
            {
                return false;
            }

            try
            {
                List<Activity> activities = new List<Activity>();
                foreach (var activityDTO in activityDTOs) {
                    activities.Add(_mapper.Map<Activity>(activityDTO));
                }
                // Call the repository method to delete the activities

                foreach (var activity in activities) {
                    await _activity_plotReleashionshipService.OnActivityDelete(activity);
                }

                var updateNotification = new UpdateNotification<List<GetActivityDTO>>
                {
                    OperationType = "Delete",
                    EntityType = "List<GetActivityDTO>",
                    UpdatedEntity = activityDTOs
                };

                await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");

                return await _activityModelRespository.DeleteActivities(activities);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                // Handle the exception as needed
                return false;
            }
        }
    }
}
