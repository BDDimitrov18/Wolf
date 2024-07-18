using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IClient_RequestRelashionshipService
    {
        public Task<List<GetClient_RequestRelashionshipDTO>> CreateClient_RequestRelashionship(GetRequestDTO requestDTO, List<GetClientDTO> clientDTOs);
        public Task<bool> OnRequestDelete(Request request);

        public Task<bool> OnClientsDelete(List<GetClientDTO> clientsDTOs);
    }
}
