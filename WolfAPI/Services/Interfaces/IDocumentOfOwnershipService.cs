using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IDocumentOfOwnershipService
    {
        public Task<GetDocumentOfOwnershipDTO> CreateDocument(CreateDocumentOfOwnershipDTO documentDTO, string clientId);
        public Task<GetDocumentOfOwnershipDTO> FindDocumentById(int id);

        public Task<bool> editDocumentOfOwnership(GetDocumentOfOwnershipDTO documentOfOwnershipDTO, string clientId);
    }
}
