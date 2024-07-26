using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class PlotService : IPlotService
    {
        private readonly IPlotModelRepository _plotModelRepository;
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public PlotService(IPlotModelRepository plotModelRepository, IMapper mapper, IWebSocketService websocketService)
        {
            _plotModelRepository = plotModelRepository;
            _mapper = mapper;
            _webSocketService = websocketService;
        }

        public async Task<GetPlotDTO> CreatePlot(CreatePlotDTO plot,string clientId) {
            var mappedPlot = _mapper.Map<Plot>(plot);
            await _plotModelRepository.Add(mappedPlot);
            var getPlotMapped = _mapper.Map<GetPlotDTO>(mappedPlot);

            var updateNotification = new UpdateNotification<GetPlotDTO>
            {
                OperationType = "Create",
                EntityType = "GetPlotDTO",
                UpdatedEntity = getPlotMapped
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return getPlotMapped;
        }
        public async Task<bool> edit(GetPlotDTO plotDTO, string clientId)
        {
            Plot plot = _mapper.Map<Plot>(plotDTO);
            var result = await _plotModelRepository.EditPlot(plot);

            var updateNotification = new UpdateNotification<GetPlotDTO>
            {
                OperationType = "Edit",
                EntityType = "GetPlotDTO",
                UpdatedEntity = plotDTO
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return result;
        }
    }

    
}
