using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IClientService
    {
        public Task<List<GetClientDTO>> AddClient(List<CreateClientDTO> clientDTOs, string clientId);

        public IEnumerable<GetClientDTO> GetAllClients();

    }
}
