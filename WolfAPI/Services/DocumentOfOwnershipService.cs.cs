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
        public IDocumentOfOwnershipModelRepository _documentOfOwnershipModelRepository { get; set; }
        public IMapper _mapper { get; set; }

        public DocumentOfOwnershipService(IDocumentOfOwnershipModelRepository documentOfOwnershipModelRepository, IMapper mapper) 
        {
            _documentOfOwnershipModelRepository = documentOfOwnershipModelRepository;
            _mapper = mapper;
        }

        public async Task<GetDocumentOfOwnershipDTO> CreateDocument(CreateDocumentOfOwnershipDTO documentDTO) { 
            DocumentOfOwnership document = _mapper.Map<DocumentOfOwnership>(documentDTO);
            await _documentOfOwnershipModelRepository.AddDocument(document);
            return _mapper.Map<GetDocumentOfOwnershipDTO>(document);
        }

        public async Task<GetDocumentOfOwnershipDTO> FindDocumentById(int id) {
            DocumentOfOwnership document = await _documentOfOwnershipModelRepository.FindById(id);
            return _mapper.Map<GetDocumentOfOwnershipDTO>(document);
        }
    }
}
