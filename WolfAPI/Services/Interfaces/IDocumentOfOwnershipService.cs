using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IDocumentOfOwnershipService
    {
        public Task<GetDocumentOfOwnershipDTO> CreateDocument(CreateDocumentOfOwnershipDTO documentDTO);
        public Task<GetDocumentOfOwnershipDTO> FindDocumentById(int id);
    }
}
