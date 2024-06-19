using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IClientService
    {
        public void AddClient(CreateClientDTO client);

        public IEnumerable<GetClientDTO> GetAllClients();
    }
}
