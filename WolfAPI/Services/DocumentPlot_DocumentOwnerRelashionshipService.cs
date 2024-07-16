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
        public IMapper _mapper { get; set; }

        public DocumentPlot_DocumentOwnerRelashionshipService(IDocumentPlot_DocumentOwnerRelashionshipModelRepository DocumentOwnerRelashionshipModelRepository,
        IMapper mapper, IPlot_DocumentOfOwnershipRelashionshipModelRepository plot_DocumentOfOwnershipRelashionshipModelRepository,
        IDocumentOfOwnership_OwnerRelashionshipModelRepository documentOfOwnership_OwnerRelashionshipModelRepository)
        {
            _DocumentOwnerRelashionshipModelRepository = DocumentOwnerRelashionshipModelRepository;
            _mapper = mapper;
            _plot_DocumentOfOwnershipRelashionshipModelRepository = plot_DocumentOfOwnershipRelashionshipModelRepository;
            _documentOfOwnership_OwnerRelashionshipModelRepository = documentOfOwnership_OwnerRelashionshipModelRepository;
        }

        public async Task<GetDocumentPlot_DocumentOwnerRelashionshipDTO> CreatePlotOwner(CreateDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO) {
            DocumentPlot_DocumentOwnerRelashionship relashionship = _mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(relashionshipDTO);
            await _DocumentOwnerRelashionshipModelRepository.AddRelashionship(relashionship);
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

        public async Task<bool> deletePlotOwnerRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs) {
            bool EndResult = true;
            foreach (var relashionship in relashionshipDTOs) {
                int DocumentPlotID = await _plot_DocumentOfOwnershipRelashionshipModelRepository.getIdOnPlotOwner(_mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(relashionship));
                int DocumentOwnerID = await _documentOfOwnership_OwnerRelashionshipModelRepository.getIdOnPlotOwner(_mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(relashionship));

                bool resultRelashionship = await _DocumentOwnerRelashionshipModelRepository.deleteRelashionship(_mapper.Map<DocumentPlot_DocumentOwnerRelashionship>(relashionship));
                bool documentPlotResult = false, documentOwnerResult = false;

                if(DocumentPlotID != -1)
                {
                    documentPlotResult = await _plot_DocumentOfOwnershipRelashionshipModelRepository.onPlotOwnerDelete(DocumentPlotID);
                }
                if (DocumentOwnerID != -1)
                {
                    documentOwnerResult = await _documentOfOwnership_OwnerRelashionshipModelRepository.onPlotOwnerDelete(DocumentOwnerID);
                }

                if (!resultRelashionship) {
                    //Log Relashionship error
                    EndResult = false;
                }
                if (!documentOwnerResult) {
                    //log documentOwnerError
                    EndResult = false;
                }
                if (!documentPlotResult) {
                    //Log documentPlotError
                    EndResult = false;
                }
            }
            return EndResult;
        }   
    }
}
