using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using Org.BouncyCastle.Asn1.Ocsp;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class Activity_PlotRelashionshipService : IActivity_PlotReleashionshipService
    {
        private readonly IWebSocketService _webSocketService;
        private readonly IActivity_PlotRelashionshipModelRepository _activityPlotModelRepository;
        private readonly IMapper _mapper;

        public Activity_PlotRelashionshipService(IActivity_PlotRelashionshipModelRepository activityPlotModelRepository, IMapper mapper, IWebSocketService webSocketService)
        {
            _activityPlotModelRepository = activityPlotModelRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
        }

        public async Task<List<GetActivity_PlotRelashionshipDTO>> CreateActivity_PlotRelashionship(List<CreateActivity_PlotRelashionshipDTO> relashionshipsDTO)
        {
            List<GetActivity_PlotRelashionshipDTO> activity_PlotRelashionshipDTOs = new List<GetActivity_PlotRelashionshipDTO>();
            List<GetPlotDTO> plots = new List<GetPlotDTO>();
            foreach(var relashionshipDTO in relashionshipsDTO)
            {
                var mappedRelashionship = _mapper.Map<Activity_PlotRelashionship>(relashionshipDTO);
                await _activityPlotModelRepository.Add(mappedRelashionship);
                activity_PlotRelashionshipDTOs.Add(_mapper.Map<GetActivity_PlotRelashionshipDTO>(mappedRelashionship));
            }
            var updateNotification = new UpdateNotification<List<GetActivity_PlotRelashionshipDTO>>
            {
                OperationType = "Create",
                UpdatedEntity = activity_PlotRelashionshipDTOs
            };

            await _webSocketService.SendMessageToAllAsync(updateNotification);

            return activity_PlotRelashionshipDTOs;
        }

        public async Task<bool> OnActivityDelete(Activity activity)
        {
            try
            {
                List<Activity_PlotRelashionship> relashionships = new List<Activity_PlotRelashionship>();
                // Attempt to delete activity plot relationships for the activity
                bool activityPlotDeletionSuccess = await _activityPlotModelRepository.OnActivityDeleteAsync(activity, relashionships);

                if (!activityPlotDeletionSuccess)
                {
                    // Log the failure
                    // Example: _logger.LogError($"Failed to delete activity plot relationships for activity ID {activity.ActivityId}");

                    List<GetActivity_PlotRelashionshipDTO> relashionshipDTOs = new List<GetActivity_PlotRelashionshipDTO>();
                    foreach(var relashionship in relashionships)
                    {
                        relashionshipDTOs.Add(_mapper.Map<GetActivity_PlotRelashionshipDTO>(relashionship));
                    }

                    var updateNotification = new UpdateNotification<List<GetActivity_PlotRelashionshipDTO>>
                    {
                        OperationType = "Delete",
                        UpdatedEntity = relashionshipDTOs
                    };

                    await _webSocketService.SendMessageToAllAsync(updateNotification);

                    return false;
                }

                // If the deletion was successful, return true
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                // Example: _logger.LogError(ex, $"An error occurred while deleting activity plot relationships for activity ID {activity.ActivityId}");

                // Return false to indicate failure
                return false;
            }
        }

        public async Task<bool> OnPlotRelashionshipRemove(List<GetActivity_PlotRelashionshipDTO> plotsDTO)
        {
            bool flag = true;
            try
            {
                
                foreach (var relashionship in plotsDTO)
                {
                    var plot = _mapper.Map<Activity_PlotRelashionship>(relashionship);

                    // Attempt to delete activity plot relationships for the activity
                    if (!(await _activityPlotModelRepository.OnPlotRelashionshipRemove(plot)))
                    {
                        flag = false;
                    }
                    else { 
                        
                    }
                }

                if (!flag)
                {
                    // Log the failure
                    // Example: _logger.LogError($"Failed to delete activity plot relationships for activity ID {activity.ActivityId}");
                    return false;
                }

                var updateNotification = new UpdateNotification<List<GetActivity_PlotRelashionshipDTO>>
                {
                    OperationType = "Delete",
                    UpdatedEntity = plotsDTO
                };

                await _webSocketService.SendMessageToAllAsync(updateNotification);
                // If the deletion was successful, return true
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                // Example: _logger.LogError(ex, $"An error occurred while deleting activity plot relationships for activity ID {activity.ActivityId}");

                // Return false to indicate failure
                return false;
            }
        }
    }
}
