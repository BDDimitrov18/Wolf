using DataAccessLayer.Models;
using DTOS.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IPowerOfAttorneyDocumentService _powerOfAttorneyDocumentService;
        public UserController(IClientService clientService, IRequestService requestService, IClient_RequestRelashionshipService requestRelashionshipService,
            IActivityTypesService activityTypesService, IEmployeeService employeeService, ItaskTypesService taskTypesService, IAcitvityService acitvityService,
            ItaskServices taskService, IPlotService plotService, IActivity_PlotReleashionshipService activityPlotReleashionshipService, IDocumentOfOwnershipService documentOfOwnershipService,
            IOwnerService ownerService, IDocumentOfOwnership_OwnerRelashionshipService ownerDocumentOfOwnershipService, IPlot_DocumentOfOwnershipRelashionshipService plot_DocumentOfOwnershipRelashionshipService,
            IDocumentPlot_DocumentOwnerRelashionshipService documentPlot_DocumentOwnerRelashionshipService, IPowerOfAttorneyDocumentService powerOfAttorneyDocumentService)
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
            _powerOfAttorneyDocumentService = powerOfAttorneyDocumentService;
        }

        [HttpPost("CreateClient")]
        public async Task<List<GetClientDTO>> CreateClient([FromBody] List<CreateClientDTO> clientDTOs) {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _clientService.AddClient(clientDTOs, clientId);
        }

        [HttpGet("GetAllClients")]

        public IEnumerable<GetClientDTO> GetAllClients()
        {
            return _clientService.GetAllClients();
        }

        [HttpPost("CreateWorkRequest")]

        public async Task<List<GetRequestDTO>> CreateWorkRequest([FromBody] List<CreateRequestDTO> requestDTO) {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _requestService.Add(requestDTO, clientId);
        }

        [HttpPost("LinkClientsAndRequest")]

        public async Task<List<GetClient_RequestRelashionshipDTO>> LinkClientsWithRequest([FromBody] RequestWithClientsDTO compositeRequestDTO) {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _client_RequestRelashionshipService.CreateClient_RequestRelashionship(compositeRequestDTO.requestDTO, compositeRequestDTO.clientDTOs,clientId);
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
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _activityTypesService.CreateActivityTypes(activityTypeDTOs,clientId);
        }

        [HttpPost("CreateTaskType")]

        public async Task<GetActivityTypeDTO> createTaskTypes([FromBody] List<CreateTaskTypeDTO> TaskTypesDTO) {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _taskTypesService.AddTaskTypes(TaskTypesDTO,clientId);
        }

        [HttpPost("CreateActivity")]
        public async Task<GetActivityDTO> createActivity([FromBody] CreateActivityDTO createActivityDTO) {
            return await _acitvityService.CreateActivitiy(createActivityDTO);
        }

        [HttpPost("CreateTask")]

        public async Task<GetActivityDTO> createTask([FromBody] CreateTaskDTO taskDto)
        {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _taskService.CreateTask(taskDto,clientId);
        }

        [HttpPost("CreatePlot")]

        public async Task<GetPlotDTO> createPlot([FromBody] CreatePlotDTO plotDTO)
        {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _plotService.CreatePlot(plotDTO, clientId);
        }

        [HttpPost("CreateActivity_PlotRelashionship")]
        public async Task<List<GetActivity_PlotRelashionshipDTO>> CreateActivity_PlotReleashionship(List<CreateActivity_PlotRelashionshipDTO> activity_PlotRelashionshipsDTO) {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _activityPlotReleashionshipService.CreateActivity_PlotRelashionship(activity_PlotRelashionshipsDTO, clientId);
        }

        [HttpPost("CreateDocumentOfOwnership")]

        public async Task<GetDocumentOfOwnershipDTO> CreateDocumentOfOwnership([FromBody] CreateDocumentOfOwnershipDTO documentOfOwnershipDTO) {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _documentOfOwnershipService.CreateDocument(documentOfOwnershipDTO,clientId);
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
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _documentPlot_DocumentOwnerRelashionshipService.CreatePlotOwner(relashionshipDTO, clientId);
        }

        [HttpPost("GetLinkedPlotOwnerRelashionships")]

        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> GetLinkedPlotOwnerRelashionships(List<GetPlotDTO> plots) {
            return _documentPlot_DocumentOwnerRelashionshipService.GetLinkedByPlots(plots);
        }

        [HttpPost("DeleteRequest")]

        public async Task<IActionResult> DeleteRequestsAsync([FromBody] List<GetRequestDTO> requestDTOs)
        {
            if (requestDTOs == null || !requestDTOs.Any())
            {
                return BadRequest(new { message = "Request data is null or empty" });
            }
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);

            bool success = await _requestService.Delete(requestDTOs,clientId);

            if (success)
            {
                return Ok(new { message = "Requests and related entities successfully deleted" });
            }
            else
            {
                return StatusCode(500, new { message = "An error occurred while deleting the requests and related entities" });
            }
        }

        [HttpPost("DeleteClientRequestRelashionships")]
        public async Task<IActionResult> DeleteRequestClientsAsync([FromBody] List<GetClient_RequestRelashionshipDTO> getClientDTOs)
        {
            if (getClientDTOs == null || getClientDTOs.Count == 0)
            {
                return BadRequest("No clients provided for deletion.");
            }

            try
            {
                var token = GetJwtTokenFromRequest();
                var clientId = GetClientIdFromJwt(token);
                bool result = await _client_RequestRelashionshipService.OnClientsDelete(getClientDTOs,clientId);

                if (result)
                {
                    return Ok("Clients deleted successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to delete clients. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("DeleteTasks")]
        public async Task<IActionResult> DeleteTasks([FromBody] List<GetTaskDTO> getTasks)
        {
            if (getTasks == null || getTasks.Count == 0)
            {
                return BadRequest("No tasks provided for deletion.");
            }

            try
            {
                var token = GetJwtTokenFromRequest();
                var clientId = GetClientIdFromJwt(token);
                // Call the service method to delete the tasks
                bool result = await _taskService.DeleteTasks(getTasks,clientId);

                if (result)
                {
                    return Ok("Tasks deleted successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to delete tasks. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("DeleteActivities")]
        public async Task<IActionResult> DeleteActivities([FromBody] List<GetActivityDTO> activityDTOs)
        {
            if (activityDTOs == null || activityDTOs.Count == 0)
            {
                return BadRequest("No activities provided for deletion.");
            }

            try
            {
                var token = GetJwtTokenFromRequest();
                var clientId = GetClientIdFromJwt(token);
                // Call the service method to delete the activities
                bool result = await _acitvityService.DeleteActivities(activityDTOs,clientId);

                if (result)
                {
                    return Ok("Activities deleted successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to delete activities. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("CreatePowerOfAttorney")]

        public async Task<GetPowerOfAttorneyDocumentDTO> CreatePowerOfAttorney([FromBody]CreatePowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO) {
            return await _powerOfAttorneyDocumentService.createPowerOfAttorneyDocument(powerOfAttorneyDocumentDTO);
        }

        [HttpPost("ActivityPlotOnPlotRemove")]

        public async Task<IActionResult> ActivityPlotOnPlotRemove([FromBody] List<GetActivity_PlotRelashionshipDTO> plotsDTO) {
            if (plotsDTO == null)
            {
                return BadRequest("No plots provided for deletion.");
            }

            try
            {
                var token = GetJwtTokenFromRequest();
                var clientId = GetClientIdFromJwt(token);
                // Call the service method to delete the activities
                bool result = await _activityPlotReleashionshipService.OnPlotRelashionshipRemove(plotsDTO, clientId);

                if (result)
                {
                    return Ok("Plots deleted successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to remove Plots. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("deletePlotOwnerRelashionships")]

        public async Task<IActionResult> deletePlotOwnerRelashionships([FromBody] List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs) {
            if (relashionshipDTOs == null)
            {
                return BadRequest("No plots provided for deletion.");
            }

            try
            {
                var token = GetJwtTokenFromRequest();
                var clientId = GetClientIdFromJwt(token);
                // Call the service method to delete the activities
                bool result = await _documentPlot_DocumentOwnerRelashionshipService.deletePlotOwnerRelashionships(relashionshipDTOs,clientId);

                if (result)
                {
                    return Ok("Relashionships deleted successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to remove Relashionships. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("EditRequest")]
        public async Task<IActionResult> EditRequest([FromBody] GetRequestDTO requestDTO)
        {
            bool result = await _requestService.EditRequestAsync(requestDTO);

            if (result)
            {
                return Ok(requestDTO); // Return the updated request DTO with HTTP 200 OK status
            }
            else
            {
                return NotFound(); // Return HTTP 404 Not Found if the request was not found
            }
        }

        [HttpPost("EditClient")]
        public async Task<IActionResult> EditClient([FromBody] GetClientDTO clientDTO)
        {
            if (clientDTO == null)
            {
                return BadRequest("Client data is null.");
            }

            bool result = await _clientService.EditClient(clientDTO);

            if (result)
            {
                return Ok(clientDTO);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error editing client.");
            }
        }

        [HttpPost("EditActivity")]
        public async Task<IActionResult> EditActivity([FromBody] GetActivityDTO activityDTO)
        {
            if (activityDTO == null)
            {
                return BadRequest("Invalid activity data.");
            }

            bool result = await _acitvityService.EditActivity(activityDTO);

            if (result)
            {
                return Ok(activityDTO);
            }
            else
            {
                return NotFound("Activity not found.");
            }
        }

        [HttpPost("EditTask")]
        public async Task<IActionResult> EditTask([FromBody] GetTaskDTO taskDTO)
        {
            if (taskDTO == null)
            {
                return BadRequest("Task data is null.");
            }

            bool result = await _taskService.EditTask(taskDTO);

            if (result)
            {
                return Ok(taskDTO);
            }
            else
            {
                return NotFound("Task not found.");
            }
        }

        [HttpPost("EditPlot")]
        public async Task<IActionResult> EditPlot([FromBody] GetPlotDTO plotDTO)
        {
            if (plotDTO == null)
            {
                return BadRequest("Plot data is null.");
            }

            bool result = await _plotService.edit(plotDTO);

            if (result)
            {
                return Ok(plotDTO);
            }
            else
            {
                return NotFound("Plot not found.");
            }
        }

        [HttpPost("EditDocumentOfOwnership")]
        public async Task<IActionResult> EditDocumentOfOwnership([FromBody] GetDocumentOfOwnershipDTO documentOfOwnershipDTO)
        {
            if (documentOfOwnershipDTO == null)
            {
                return BadRequest("Document data is null.");
            }

            bool result = await _documentOfOwnershipService.editDocumentOfOwnership(documentOfOwnershipDTO);

            if (result)
            {
                return Ok(documentOfOwnershipDTO);
            }
            else
            {
                return NotFound("Document not found.");
            }
        }

        [HttpPost("EditOwner")]
        public async Task<IActionResult> EditOwner([FromBody] GetOwnerDTO ownerDTO)
        {
            if (ownerDTO == null)
            {
                return BadRequest("Owner data is null.");
            }

            bool result = await _ownerService.editOwner(ownerDTO);

            if (result)
            {
                return Ok(ownerDTO);
            }
            else
            {
                return NotFound("Owner not found.");
            }
        }

        [HttpPost("EditPowerOfAttorneyDocument")]
        public async Task<IActionResult> EditPowerOfAttorneyDocument([FromBody] GetPowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO)
        {
            if (powerOfAttorneyDocumentDTO == null)
            {
                return BadRequest("Power of Attorney Document data is null.");
            }

            bool result = await _powerOfAttorneyDocumentService.EditPowerOfAttorneyDocument(powerOfAttorneyDocumentDTO);

            if (result)
            {
                return Ok(powerOfAttorneyDocumentDTO);
            }
            else
            {
                return NotFound("Power of Attorney Document not found.");
            }
        }

        [HttpPost("EditDocumentPlotOwnerRelationship")]
        public async Task<IActionResult> EditDocumentPlotOwnerRelationship([FromBody] GetDocumentPlot_DocumentOwnerRelashionshipDTO documentDTO)
        {
            if (documentDTO == null)
            {
                return BadRequest("Document data is null.");
            }

            bool result = await _documentPlot_DocumentOwnerRelashionshipService.editDocument(documentDTO);

            if (result)
            {
                return Ok(documentDTO);
            }
            else
            {
                return NotFound("Document relationship not found.");
            }
        }


        private string GetJwtTokenFromRequest()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();
            return authHeader.Replace("Bearer ", string.Empty);
        }

        private string GetClientIdFromJwt(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken == null)
            {
                throw new InvalidOperationException("Invalid JWT token.");
            }

            var clientIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "jti");
            if (clientIdClaim == null)
            {
                throw new InvalidOperationException("Client ID claim not found in JWT token.");
            }

            return clientIdClaim.Value;
        }


    }
}
