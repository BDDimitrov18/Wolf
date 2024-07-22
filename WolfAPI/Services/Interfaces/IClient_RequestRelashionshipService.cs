using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IClient_RequestRelashionshipService
    {
        public Task<List<GetClient_RequestRelashionshipDTO>> CreateClient_RequestRelashionship(GetRequestDTO requestDTO, List<GetClientDTO> clientDTOs, string clientId);
        public Task<bool> OnRequestDelete(Request request, string clientId);

        public Task<bool> OnClientsDelete(List<GetClient_RequestRelashionshipDTO> clientsDTOs, string clientId);
    }
}
