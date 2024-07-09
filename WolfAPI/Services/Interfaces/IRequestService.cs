using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IRequestService
    {
        public List<GetRequestDTO> Add(List<CreateRequestDTO> requestsDto);
        public List<GetRequestDTO> GetAllRequest();

        public Task<List<RequestWithClientsDTO>> GetLinked(List<GetRequestDTO> requestsDTO);

        public Task<bool> Delete(List<GetRequestDTO> requestDTOs);
    }
}
