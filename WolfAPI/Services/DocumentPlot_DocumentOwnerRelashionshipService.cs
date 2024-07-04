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
        public IMapper _mapper { get; set; }

        public DocumentPlot_DocumentOwnerRelashionshipService(IDocumentPlot_DocumentOwnerRelashionshipModelRepository DocumentOwnerRelashionshipModelRepository,
        IMapper mapper)
        {
            _DocumentOwnerRelashionshipModelRepository = DocumentOwnerRelashionshipModelRepository;
            _mapper = mapper;
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
    }
}
