﻿using DTOS.DTO;
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
        private readonly IDocumentOfOwnershipService _documentOfOwnershipService;
        private readonly IOwnerService _ownerService;
        private readonly IDocumentOfOwnership_OwnerRelashionshipService _ownerDocumentOfOwnershipService;
        private readonly IPlot_DocumentOfOwnershipRelashionshipService _plot_DocumentOfOwnershipRelashionshipService;
        private readonly IDocumentPlot_DocumentOwnerRelashionshipService _documentPlot_DocumentOwnerRelashionshipService;
        public UserController(IClientService clientService, IRequestService requestService, IClient_RequestRelashionshipService requestRelashionshipService,
            IActivityTypesService activityTypesService, IEmployeeService employeeService, ItaskTypesService taskTypesService, IAcitvityService acitvityService,
            ItaskServices taskService, IPlotService plotService, IActivity_PlotReleashionshipService activityPlotReleashionshipService, IDocumentOfOwnershipService documentOfOwnershipService,
            IOwnerService ownerService, IDocumentOfOwnership_OwnerRelashionshipService ownerDocumentOfOwnershipService, IPlot_DocumentOfOwnershipRelashionshipService plot_DocumentOfOwnershipRelashionshipService,
            IDocumentPlot_DocumentOwnerRelashionshipService documentPlot_DocumentOwnerRelashionshipService)
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
            _documentOfOwnershipService = documentOfOwnershipService;
            _ownerService = ownerService;
            _ownerDocumentOfOwnershipService = ownerDocumentOfOwnershipService;
            _plot_DocumentOfOwnershipRelashionshipService = plot_DocumentOfOwnershipRelashionshipService;
            _documentPlot_DocumentOwnerRelashionshipService = documentPlot_DocumentOwnerRelashionshipService;
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

        [HttpPost("CreateDocumentOfOwnership")]

        public async Task<GetDocumentOfOwnershipDTO> CreateDocumentOfOwnership([FromBody] CreateDocumentOfOwnershipDTO documentOfOwnershipDTO) {
            return await _documentOfOwnershipService.CreateDocument(documentOfOwnershipDTO);
        }

        [HttpPost("CreateOwner")]

        public async Task<GetOwnerDTO> CreateOwner([FromBody] CreateOwnerDTO ownerDTO) {
            return await _ownerService.CreateOwner(ownerDTO);
        }

        [HttpPost("CreateDocumentOwnerRelashionship")]

        public async Task<GetDocumentOfOwnership_OwnerRelashionshipDTO> CreateDocumentOwnerRelashionship(CreateDocumentOfOwnership_OwnerRelashionshipDTO relashionshipDTO) {
            return await _ownerDocumentOfOwnershipService.CreateDocumentOwner(relashionshipDTO);
        }

        [HttpPost("CreateDocumentPlotRelashionship")]

        public async Task<GetPlot_DocumentOfOwnershipRelashionshipDTO> CreateDocumentPlotRelashionship(CreatePlot_DocumentOfOwnershipRelashionshipDTO relashionshipDTO)
        {
            return await _plot_DocumentOfOwnershipRelashionshipService.createPlotDocument(relashionshipDTO);
        }

        [HttpPost("CreatePlotOwnerRelashionship")]

        public async Task<GetDocumentPlot_DocumentOwnerRelashionshipDTO> CreatePlotOwnerRelashionship(CreateDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO) {
            return await _documentPlot_DocumentOwnerRelashionshipService.CreatePlotOwner(relashionshipDTO);
        }

        [HttpPost("GetLinkedPlotOwnerRelashionships")]

        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> GetLinkedPlotOwnerRelashionships(List<GetPlotDTO> plots) { 
            return _documentPlot_DocumentOwnerRelashionshipService.GetLinkedByPlots(plots);
        }


        //public void LinkClientsAdnRequest([FromBody] IEnumerable<GetClientDTO>)
    }
}
