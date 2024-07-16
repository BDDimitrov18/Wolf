using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class Activity_PlotRelashionshipService : IActivity_PlotReleashionshipService
    {
        private readonly IActivity_PlotRelashionshipModelRepository _activityPlotModelRepository;
        private readonly IMapper _mapper;

        public Activity_PlotRelashionshipService(IActivity_PlotRelashionshipModelRepository activityPlotModelRepository, IMapper mapper)
        {
            _activityPlotModelRepository = activityPlotModelRepository;
            _mapper = mapper;
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

            return activity_PlotRelashionshipDTOs;
        }

        public async Task<bool> OnActivityDelete(Activity activity)
        {
            try
            {
                // Attempt to delete activity plot relationships for the activity
                bool activityPlotDeletionSuccess = await _activityPlotModelRepository.OnActivityDeleteAsync(activity);

                if (!activityPlotDeletionSuccess)
                {
                    // Log the failure
                    // Example: _logger.LogError($"Failed to delete activity plot relationships for activity ID {activity.ActivityId}");
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
                    if (!(await _activityPlotModelRepository.OnPlotRelashionshipRemove(plot))) {
                        flag = false;
                    }
                    
                }

                if (!flag)
                {
                    // Log the failure
                    // Example: _logger.LogError($"Failed to delete activity plot relationships for activity ID {activity.ActivityId}");
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
    }
}
