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
        private readonly IPlotService _plotService;
        private readonly IActivity_PlotReleashionshipService _activityPlotReleashionshipService;
        public UserController(IClientService clientService, IRequestService requestService, IClient_RequestRelashionshipService requestRelashionshipService,
            IActivityTypesService activityTypesService, IEmployeeService employeeService, ItaskTypesService taskTypesService, IAcitvityService acitvityService,
            ItaskServices taskService, IPlotService plotService, IActivity_PlotReleashionshipService activityPlotReleashionshipService)
        {
            _clientService = clientService;
            _requestService = requestService;
            _client_RequestRelashionshipService = requestRelashionshipService;
            _activityTypesService = activityTypesService;
            _employeeService = employeeService;
            _taskTypesService = taskTypesService;
            _acitvityService = acitvityService;
            _taskService = taskService;
            _plotService = plotService;
            _activityPlotReleashionshipService = activityPlotReleashionshipService;
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

        public async Task<List<RequestWithClientsDTO>> getLinked([FromBody] List<GetRequestDTO> requestDTOs) {
            return await _requestService.GetLinked(requestDTOs);
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

        public async Task<List<GetActivityTypeDTO>> createActivityType([FromBody] List<CreateActivityTypeDTO> activityTypeDTOs) {
            return await _activityTypesService.CreateActivityTypes(activityTypeDTOs);
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

        [HttpPost("CreatePlot")]

        public async Task<GetPlotDTO> createPlot([FromBody] CreatePlotDTO plotDTO)
        {
            return await _plotService.CreatePlot(plotDTO);
        }

        [HttpPost("CreateActivity_PlotRelashionship")]
        public async Task<List<GetActivity_PlotRelashionshipDTO>> CreateActivity_PlotReleashionship(List<CreateActivity_PlotRelashionshipDTO> activity_PlotRelashionshipsDTO) {
            return await _activityPlotReleashionshipService.CreateActivity_PlotRelashionship(activity_PlotRelashionshipsDTO);
        }
        //public void LinkClientsAdnRequest([FromBody] IEnumerable<GetClientDTO>)
    }
}
