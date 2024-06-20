using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IClientService
    {
        public List<GetClientDTO> AddClient(List<CreateClientDTO> clientDTOs);

        public IEnumerable<GetClientDTO> GetAllClients();
    }
}
