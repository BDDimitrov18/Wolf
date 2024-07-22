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
        private readonly IDocumentPlot_DocumentOwnerRelashionshipModelRepository _DocumentModelRepository;
        private readonly IMapper _mapper;

        public Activity_PlotRelashionshipService(IActivity_PlotRelashionshipModelRepository activityPlotModelRepository,
            IMapper mapper, IWebSocketService webSocketService, IDocumentPlot_DocumentOwnerRelashionshipModelRepository documentModelRepository)
        {
            _activityPlotModelRepository = activityPlotModelRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
            _DocumentModelRepository = documentModelRepository;
        }

        public async Task<List<GetActivity_PlotRelashionshipDTO>> CreateActivity_PlotRelashionship(List<CreateActivity_PlotRelashionshipDTO> relashionshipsDTO, string clientId)
        {
            List<GetActivity_PlotRelashionshipDTO> activity_PlotRelashionshipDTOs = new List<GetActivity_PlotRelashionshipDTO>();
            List<GetPlotDTO> plots = new List<GetPlotDTO>();
            foreach(var relashionshipDTO in relashionshipsDTO)
            {
                var mappedRelashionship = _mapper.Map<Activity_PlotRelashionship>(relashionshipDTO);
                await _activityPlotModelRepository.Add(mappedRelashionship);
                activity_PlotRelashionshipDTOs.Add(_mapper.Map<GetActivity_PlotRelashionshipDTO>(mappedRelashionship));
            }
            List<Plot> listOfPlots = new List<Plot>();
            HashSet<int> uniquePlotIds = new HashSet<int>();

            foreach (var relashionship in activity_PlotRelashionshipDTOs)
            {
                if (relashionship.Plot != null && uniquePlotIds.Add(relashionship.PlotId))
                {
                    listOfPlots.Add(_mapper.Map<Plot>(relashionship.Plot));
                }
            }

            List<DocumentPlot_DocumentOwnerRelashionship> listOfRelashionships = new List<DocumentPlot_DocumentOwnerRelashionship>();
            listOfRelashionships = _DocumentModelRepository.GetLinked(listOfPlots);

            List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> listOfRelashionshipsDTO = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            foreach (var documentPlot in listOfRelashionships) {
                listOfRelashionshipsDTO.Add(_mapper.Map<GetDocumentPlot_DocumentOwnerRelashionshipDTO>(documentPlot));
            }

            GetActivity_Plot_OwnershipDTO getActivity_Plot_OwnershipDTO = new GetActivity_Plot_OwnershipDTO();
            getActivity_Plot_OwnershipDTO.activity_PlotRelashionshipDTOs = activity_PlotRelashionshipDTOs;
            getActivity_Plot_OwnershipDTO.getDocumentPlot_DocumentOwnerRelashionshipDTOs = listOfRelashionshipsDTO;

            var updateNotification = new UpdateNotification<GetActivity_Plot_OwnershipDTO>
            {
                OperationType = "Create",
                EntityType = "GetActivity_Plot_OwnershipDTO",
                UpdatedEntity = getActivity_Plot_OwnershipDTO
            };

            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");

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

        public async Task<bool> OnPlotRelashionshipRemove(List<GetActivity_PlotRelashionshipDTO> plotsDTO,string clientId)
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
                    EntityType = "List<GetActivity_PlotRelashionshipDTO>",
                    UpdatedEntity = plotsDTO
                };

                await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
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
