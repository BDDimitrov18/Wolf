using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IDocumentOfOwnership_OwnerRelashionshipService
    {
        public Task<GetDocumentOfOwnership_OwnerRelashionshipDTO> CreateDocumentOwner(CreateDocumentOfOwnership_OwnerRelashionshipDTO relashionshipDTO);
        public Task<GetDocumentOfOwnership_OwnerRelashionshipDTO> FindById(int id);
    }
}
