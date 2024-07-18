using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using System.Runtime.InteropServices;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class DocumentOfOwnershipService : IDocumentOfOwnershipService
    {
        public IDocumentOfOwnershipModelRepository _documentOfOwnershipModelRepository;
        private readonly IWebSocketService _webSocketService;
        public IMapper _mapper;

        public DocumentOfOwnershipService(IDocumentOfOwnershipModelRepository documentOfOwnershipModelRepository, IMapper mapper,IWebSocketService webSocketService) 
        {
            _documentOfOwnershipModelRepository = documentOfOwnershipModelRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
        }

        public async Task<GetDocumentOfOwnershipDTO> CreateDocument(CreateDocumentOfOwnershipDTO documentDTO) { 
            DocumentOfOwnership document = _mapper.Map<DocumentOfOwnership>(documentDTO);
            await _documentOfOwnershipModelRepository.AddDocument(document);

            var updateNotification = new UpdateNotification<GetDocumentOfOwnershipDTO>
            {
                OperationType = "Create",
                UpdatedEntity = _mapper.Map<GetDocumentOfOwnershipDTO>(document)
            };
            await _webSocketService.SendMessageToAllAsync(updateNotification);

            return _mapper.Map<GetDocumentOfOwnershipDTO>(document);
        }

        public async Task<GetDocumentOfOwnershipDTO> FindDocumentById(int id) {
            DocumentOfOwnership document = await _documentOfOwnershipModelRepository.FindById(id);
            return _mapper.Map<GetDocumentOfOwnershipDTO>(document);
        }
    }
}
