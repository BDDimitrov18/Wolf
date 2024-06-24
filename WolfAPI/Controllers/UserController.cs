using DTOS.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IRequestService _requestService;
        private readonly IClient_RequestRelashionshipService _client_RequestRelashionshipService;

        public UserController(IClientService clientService, IRequestService requestService, IClient_RequestRelashionshipService requestRelashionshipService)
        {
            _clientService = clientService;
            _requestService = requestService;
            _client_RequestRelashionshipService = requestRelashionshipService;
        }

        [HttpPost("CreateClient")]
        public List<GetClientDTO> CreateClient([FromBody] List<CreateClientDTO> clientDTOs) {
            return _clientService.AddClient(clientDTOs);
        }

        [HttpGet("GetAllClients")]

        public IEnumerable<GetClientDTO> GetAllClients()
        {
            return _clientService.GetAllClients();
        }

        [HttpPost("CreateWorkRequest")]

        public List<GetRequestDTO> CreateWorkRequest([FromBody] List<CreateRequestDTO> requestDTO) {
            return _requestService.Add(requestDTO);
        }

        [HttpPost("LinkClientsAndRequest")]

        public List<GetClient_RequestRelashionshipDTO> LinkClientsWithRequest([FromBody] CompositeRequestDTO compositeRequestDTO) { 
             return _client_RequestRelashionshipService.CreateClient_RequestRelashionship(compositeRequestDTO.RequestDTO, compositeRequestDTO.ClientsList);
        }

        [HttpGet("GetAllRequests")]

        public List<GetRequestDTO> getAllRequests() {
            return _requestService.GetAllRequest();
        }

        [HttpPost("GetLinkedClients")]

        public List<RequestWithClientsDTO> getLinkedClients([FromBody] List<GetRequestDTO> requestDTOs) {
            return _clientService.GetLinkedClients(requestDTOs);    
        }
        //public void LinkClientsAdnRequest([FromBody] IEnumerable<GetClientDTO>)
    }
}
