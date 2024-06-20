using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Models;

namespace WolfClient.Services.Interfaces
{
    public interface IUserClient
    {
        public void SetToken(string token);
        public Task<ClientResponse<List<GetClientDTO>>> AddClients(List<CreateClientDTO> clients);

        public Task<ClientResponse<IEnumerable<GetClientDTO>>> GetAllClients();

        public Task<ClientResponse<List<GetRequestDTO>>> AddRequests(List<CreateRequestDTO> requestDTOs);
    }
}
