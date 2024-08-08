using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class DocumentPlot_DocumentOwnerRelashionshipService : IDocumentPlot_DocumentOwnerRelashionshipService
    {
        public IDocumentPlot_DocumentOwnerRelashionshipModelRepository _DocumentOwnerRelashionshipModelRepository { get; set; }

        public IPlot_DocumentOfOwnershipRelashionshipModelRepository _plot_DocumentOfOwnershipRelashionshipModelRepository { get; set; }
        public IDocumentOfOwnership_OwnerRelashionshipModelRepository _documentOfOwnership_OwnerRelashionshipModelRepository { get; set; }
        private readonly IWebSocketService _webSocketService;
        public IMapper _mapper { get; set; }

        public DocumentPlot_DocumentOwnerRelashionshipService(IDocumentPlot_DocumentOwnerRelashionshipModelRepository DocumentOwnerRelashionshipModelRepository,
        IMapper mapper, IPlot_DocumentOfOwnershipRelashionshipModelRepository plot_DocumentOfOwnershipRelashionshipModelRepository,
        IDocumentOfOwnership_OwnerRelashionshipModelRepository documentOfOwnership_OwnerRelashionshipModelRepository, IWebSocketService websocketService)
        {
            _DocumentOwnerRelashionshipModelRepository = DocumentOwnerRelashionshipModelRepository;
            _mapper = mapper;
            _plot_DocumentOfOwnershipRelashionshipModelRepository = plot_DocumentOfOwnershipRelashionshipModelRepository;
            _documentOfOwnership_OwnerRelashionshipModelRepository = documentOfOwnership_OwnerRelashionshipModelRepository;
            _webSocketService = websocketService;
        }

        public async Task<GetDocumentPlot_DocumentOwnerRelashionshipDTO> CreatePlotOwner(CreateDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO, string clientId) {
            DocumentPlot_DocumentOwnerRelashionship relashionship = _mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(relashionshipDTO);
            await _DocumentOwnerRelashionshipModelRepository.AddRelashionship(relashionship);

            var updateNotification = new UpdateNotification<GetDocumentPlot_DocumentOwnerRelashionshipDTO>
            {
                OperationType = "Create",
                EntityType = "GetDocumentPlot_DocumentOwnerRelashionshipDTO",
                UpdatedEntity = _mapper.Map<GetDocumentPlot_DocumentOwnerRelashionshipDTO>(relashionship)
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification,clientId, "admin", "user");

            return _mapper.Map<GetDocumentPlot_DocumentOwnerRelashionshipDTO>(relashionship);
        }

        public async Task<GetDocumentPlot_DocumentOwnerRelashionshipDTO> FindById(int id) {
            DocumentPlot_DocumentOwnerRelashionship relashionship = await _DocumentOwnerRelashionshipModelRepository.FindById(id);
            return _mapper.Map<GetDocumentPlot_DocumentOwnerRelashionshipDTO>(relashionship);
        }

        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> GetLinkedByPlots(List<GetPlotDTO> getPlots) {
            List<Plot> plots = new List<Plot>();
            foreach (GetPlotDTO plot in getPlots)
            {
                plots.Add(_mapper.Map<Plot>(plot));
            }
            var result = _DocumentOwnerRelashionshipModelRepository.GetLinked(plots);

            List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> returnList = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            foreach (var rel in result) {
                returnList.Add(_mapper.Map<GetDocumentPlot_DocumentOwnerRelashionshipDTO>(rel));
            }
            return returnList; 
        }

        public async Task<bool> deletePlotOwnerRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs, string clientId) {
            bool EndResult = true;
            List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOsReturAll = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            foreach (var relashionship in relashionshipDTOs) {
                int DocumentPlotID = await _plot_DocumentOfOwnershipRelashionshipModelRepository.getIdOnPlotOwner(_mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(relashionship));
                int DocumentOwnerID = await _documentOfOwnership_OwnerRelashionshipModelRepository.getIdOnPlotOwner(_mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(relashionship));

                DocumentPlot_DocumentOwnerRelashionship plotOwner = new DocumentPlot_DocumentOwnerRelashionship();
                bool resultRelashionship = await _DocumentOwnerRelashionshipModelRepository.deleteRelashionship(_mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(relashionship), plotOwner);
                bool documentPlotResult = false, documentOwnerResult = false;

                if (DocumentPlotID != -1)
                {
                    documentPlotResult = await _plot_DocumentOfOwnershipRelashionshipModelRepository.onPlotOwnerDelete(DocumentPlotID);
                }
                if (DocumentOwnerID != -1)
                {
                    documentOwnerResult = await _documentOfOwnership_OwnerRelashionshipModelRepository.onPlotOwnerDelete(DocumentOwnerID);
                }

                if(DocumentPlotID != -1 )

                if (!resultRelashionship)
                {
                    //Log Relashionship error
                    EndResult = false;
                }
                else {
                    var updateNotification = new UpdateNotification<DocumentPlot_DocumentOwnerRelashionship>
                    {
                        OperationType = "Delete",
                        EntityType = "DocumentPlot_DocumentOwnerRelashionship",
                        UpdatedEntity = plotOwner
                    };
                    await _webSocketService.SendMessageToRolesAsync(updateNotification,clientId, "admin", "user");
                    relashionshipDTOsReturAll.Add(_mapper.Map<GetDocumentPlot_DocumentOwnerRelashionshipDTO>(plotOwner));
                }
                if (!documentOwnerResult)
                {

                    //log documentOwnerError
                    EndResult = false;
                }
                else {

                }
                if (!documentPlotResult)
                {
                    //Log documentPlotError
                    EndResult = false;
                }
                else {

                }
            }


            if (EndResult)
            {
                var updateNotification = new UpdateNotification<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>>
                {
                    OperationType = "Delete",
                    EntityType = "List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>",
                    UpdatedEntity = relashionshipDTOs
                };
                await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            }
            return EndResult;
        }

        public async Task<bool> editDocument(GetDocumentPlot_DocumentOwnerRelashionshipDTO documentDTO,string clientId) {
            DocumentPlot_DocumentOwnerRelashionship document = _mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(documentDTO);
            var updateNotification = new UpdateNotification<GetDocumentPlot_DocumentOwnerRelashionshipDTO>
            {
                OperationType = "Edit",
                EntityType = "GetDocumentPlot_DocumentOwnerRelashionshipDTO",
                UpdatedEntity = documentDTO
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return await _DocumentOwnerRelashionshipModelRepository.EditRelashionship(document);
        }

        public async Task<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> FetchLinkedRelashionships(GetPlotDTO plotDTO) { 
            Plot plot = _mapper.Map<Plot>(plotDTO);
            List<DocumentPlot_DocumentOwnerRelashionship> relashionships = await _DocumentOwnerRelashionshipModelRepository.FetchLinkedRelashionships(plot);
            List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            foreach (var relashionship in relashionships) {
                relashionshipDTOs.Add(_mapper.Map<GetDocumentPlot_DocumentOwnerRelashionshipDTO>(relashionship));
            }
            return relashionshipDTOs;
        }
    }
}
