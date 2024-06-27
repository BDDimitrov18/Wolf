using DTOS.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WolfAPI.Services;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Controllers
{
    [Authorize(Roles = "admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IRequestService _requestService;
        private readonly IClient_RequestRelashionshipService _client_RequestRelashionshipService;
        private readonly IActivityTypesService _activityTypesService;
        private readonly IEmployeeService _employeeService;
        private readonly ItaskTypesService _taskTypesService;
        private readonly IAcitvityService _acitvityService;
        private readonly ItaskServices _taskService;
        public UserController(IClientService clientService, IRequestService requestService, IClient_RequestRelashionshipService requestRelashionshipService,
            IActivityTypesService activityTypesService, IEmployeeService employeeService, ItaskTypesService taskTypesService, IAcitvityService acitvityService,
            ItaskServices taskService)
        {
            _clientService = clientService;
            _requestService = requestService;
            _client_RequestRelashionshipService = requestRelashionshipService;
            _activityTypesService = activityTypesService;
            _employeeService = employeeService;
            _taskTypesService = taskTypesService;
            _acitvityService = acitvityService;
            _taskService = taskService;
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

        public List<GetClient_RequestRelashionshipDTO> LinkClientsWithRequest([FromBody] RequestWithClientsDTO compositeRequestDTO) {
            return _client_RequestRelashionshipService.CreateClient_RequestRelashionship(compositeRequestDTO.requestDTO, compositeRequestDTO.clientDTOs);
        }

        [HttpGet("GetAllRequests")]

        public List<GetRequestDTO> getAllRequests() {
            return _requestService.GetAllRequest();
        }

        [HttpPost("GetLinkedClients")]

        public List<RequestWithClientsDTO> getLinkedClients([FromBody] List<GetRequestDTO> requestDTOs) {
            return _requestService.GetLinked(requestDTOs);
        }

        [HttpGet("GetActivityTypes")]

        public List<GetActivityTypeDTO> getActivityTypes() {
            return _activityTypesService.GetAll();
        }

        [HttpGet("GetAllEmployees")]

        public IEnumerable<GetEmployeeDTO> GetAllEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        [HttpPost("CreateActivityTypes")]

        public List<GetActivityTypeDTO> createActivityType([FromBody] List<CreateActivityTypeDTO> activityTypeDTOs) {
            return _activityTypesService.CreateActivityTypes(activityTypeDTOs);
        }

        [HttpPost("CreateTaskType")]

        public async Task<GetActivityTypeDTO> createTaskTypes([FromBody] List<CreateTaskTypeDTO> TaskTypesDTO) {
            return await _taskTypesService.AddTaskTypes(TaskTypesDTO);
        }

        [HttpPost("CreateActivity")]
        public async Task<GetActivityDTO> createActivity([FromBody] CreateActivityDTO createActivityDTO) {
            return await _acitvityService.CreateActivitiy(createActivityDTO);
        }

        [HttpPost("CreateTask")]

        public async Task<GetActivityDTO> createTask([FromBody] CreateTaskDTO taskDto) 
        {
            return await _taskService.CreateTask(taskDto);
        }
        //public void LinkClientsAdnRequest([FromBody] IEnumerable<GetClientDTO>)
    }
}
