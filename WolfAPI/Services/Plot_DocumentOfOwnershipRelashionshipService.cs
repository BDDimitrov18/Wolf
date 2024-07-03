using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class Plot_DocumentOfOwnershipRelashionshipService : IPlot_DocumentOfOwnershipRelashionshipService
    {
        public IPlot_DocumentOfOwnershipRelashionshipModelRepository _DocumentOfOwnershipRelashionshipModelRepository { get; set; }
        public IMapper  _mapper { get; set; }

        public Plot_DocumentOfOwnershipRelashionshipService(IPlot_DocumentOfOwnershipRelashionshipModelRepository DocumentOfOwnershipRelashionshipModelRepository, IMapper mapper)
        {
            _DocumentOfOwnershipRelashionshipModelRepository =  DocumentOfOwnershipRelashionshipModelRepository;
            _mapper = mapper;
        }

        public async Task<GetPlot_DocumentOfOwnershipRelashionshipDTO> createPlotDocument(CreatePlot_DocumentOfOwnershipRelashionshipDTO relashionshipDTO) {
            Plot_DocumentOfOwnershipRelashionship relashionship = _mapper.Map<Plot_DocumentOfOwnershipRelashionship>(relashionshipDTO);
            await _DocumentOfOwnershipRelashionshipModelRepository.AddRelashionship(relashionship);
            return _mapper.Map<GetPlot_DocumentOfOwnershipRelashionshipDTO>(relashionship);
        }

        public async Task<GetPlot_DocumentOfOwnershipRelashionshipDTO> FindById(int id) {
            Plot_DocumentOfOwnershipRelashionship relashionship = await  _DocumentOfOwnershipRelashionshipModelRepository.FindById(id);
            return _mapper.Map<GetPlot_DocumentOfOwnershipRelashionshipDTO>(relashionship);
        }
    }
}
