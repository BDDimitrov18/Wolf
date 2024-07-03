using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IOwnerService
    {
        public Task<GetOwnerDTO> CreateOwner(CreateOwnerDTO ownerDTO);
        public Task<GetOwnerDTO> FindOwnerById(int id);
    }

}
