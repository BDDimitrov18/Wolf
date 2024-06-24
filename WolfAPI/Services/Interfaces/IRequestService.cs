using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IRequestService
    {
        public List<GetRequestDTO> Add(List<CreateRequestDTO> requestsDto);
        public List<GetRequestDTO> GetAllRequest();
    }
}
