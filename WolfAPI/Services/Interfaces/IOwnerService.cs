using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IOwnerService
    {
        public Task<GetOwnerDTO> CreateOwner(CreateOwnerDTO ownerDTO);
        public Task<GetOwnerDTO> FindOwnerById(int id);
        public Task<bool> editOwner(GetOwnerDTO ownerDTO, string clientId);

        public Task<List<GetOwnerDTO>> getAllOwners();
    }

}
