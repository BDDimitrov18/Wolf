using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class DocumentOfOwnership_OwnerRelashionshipService : IDocumentOfOwnership_OwnerRelashionshipService
    {
        public IDocumentOfOwnership_OwnerRelashionshipModelRepository _DocumentOfOwnership_OwnerRelashionshipModelRepository;
        private readonly IWebSocketService _webSocketService;
        public IMapper _mapper;

        public DocumentOfOwnership_OwnerRelashionshipService(IDocumentOfOwnership_OwnerRelashionshipModelRepository DocumentOfOwnership_OwnerRelashionshipModelRepository,
        IMapper mapper,
        IWebSocketService webSocketService)
        {
            _DocumentOfOwnership_OwnerRelashionshipModelRepository = DocumentOfOwnership_OwnerRelashionshipModelRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
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
