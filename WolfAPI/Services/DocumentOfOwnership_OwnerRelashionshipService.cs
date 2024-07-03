using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class DocumentOfOwnership_OwnerRelashionshipService : IDocumentOfOwnership_OwnerRelashionshipService
    {
        public IDocumentOfOwnership_OwnerRelashionshipModelRepository _DocumentOfOwnership_OwnerRelashionshipModelRepository { get; set; }
        public IMapper _mapper { get; set; }

        public DocumentOfOwnership_OwnerRelashionshipService(IDocumentOfOwnership_OwnerRelashionshipModelRepository DocumentOfOwnership_OwnerRelashionshipModelRepository,
        IMapper mapper)
        {
            _DocumentOfOwnership_OwnerRelashionshipModelRepository = DocumentOfOwnership_OwnerRelashionshipModelRepository;
            _mapper = mapper;
        }

        public async Task<GetDocumentOfOwnership_OwnerRelashionshipDTO> CreateDocumentOwner(CreateDocumentOfOwnership_OwnerRelashionshipDTO relashionshipDTO)
        {
            DocumentOfOwnership_OwnerRelashionship relashionship = _mapper.Map<DocumentOfOwnership_OwnerRelashionship>(relashionshipDTO);
            await _DocumentOfOwnership_OwnerRelashionshipModelRepository.AddRelashionship(relashionship);
            return _mapper.Map<GetDocumentOfOwnership_OwnerRelashionshipDTO>(relashionship);
        }

        public async Task<GetDocumentOfOwnership_OwnerRelashionshipDTO> FindById(int id) {
            DocumentOfOwnership_OwnerRelashionship relashionship = await  _DocumentOfOwnership_OwnerRelashionshipModelRepository.FindById(id);
            return _mapper.Map<GetDocumentOfOwnership_OwnerRelashionshipDTO>(relashionship);
        }
    }
}
