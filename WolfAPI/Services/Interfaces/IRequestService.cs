using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IRequestService
    {
        public Task<List<GetRequestDTO>> Add(List<CreateRequestDTO> requestsDto, string clientId);
        public List<GetRequestDTO> GetAllRequest();

        public Task<List<RequestWithClientsDTO>> GetLinked(List<GetRequestDTO> requestsDTO);

        public Task<bool> Delete(List<GetRequestDTO> requestDTOs, string clientId);
        public Task<bool> EditRequestAsync(GetRequestDTO requestDTO);


    }
}
