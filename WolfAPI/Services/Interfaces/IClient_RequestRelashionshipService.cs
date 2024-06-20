using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IClient_RequestRelashionshipService
    {
        public List<GetClient_RequestRelashionshipDTO> CreateClient_RequestRelashionship(GetRequestDTO requestDTO, List<GetClientDTO> clientDTOs);
    }
}
