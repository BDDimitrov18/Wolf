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

        public Task<ClientResponse<List<GetClient_RequestRelashionshipDTO>>> LinkClientsWithRequest(GetRequestDTO requestDTO, List<GetClientDTO> _clientsList);

        public Task<ClientResponse<List<GetRequestDTO>>> GetAllRequests();

        public Task<ClientResponse<List<RequestWithClientsDTO>>> GetLinked(List<GetRequestDTO> requestDTOs);

        public Task<ClientResponse<List<GetActivityTypeDTO>>> GetActivityTypes();

        public Task<ClientResponse<IEnumerable<GetEmployeeDTO>>> GetAllEmployees();

        public Task<ClientResponse<List<GetActivityTypeDTO>>> AddActivityTypes(List<CreateActivityTypeDTO> activityTypeDTOs);

        public Task<ClientResponse<GetActivityTypeDTO>> AddTaskTypes(List<CreateTaskTypeDTO> taskTypesDTOs);

        public Task<ClientResponse<GetActivityDTO>> AddActivity(CreateActivityDTO activityDTO);

        public Task<ClientResponse<GetActivityDTO>> AddTask(CreateTaskDTO taskDTO);

        public Task<ClientResponse<GetPlotDTO>> AddPlot(CreatePlotDTO plotDto);

        public Task<ClientResponse<List<GetActivity_PlotRelashionshipDTO>>> AddActivity_PlotRelashionship(List<CreateActivity_PlotRelashionshipDTO> activity_PlotRelashionshipDTOs);

        public Task<ClientResponse<GetDocumentOfOwnershipDTO>> AddDocumentOfOwnership(CreateDocumentOfOwnershipDTO documentOfOwnershipDTO);

        public Task<ClientResponse<GetOwnerDTO>> AddOwner(CreateOwnerDTO ownerDTO);

        public Task<ClientResponse<GetDocumentOfOwnership_OwnerRelashionshipDTO>> AddDocumentOwnerRelashionship(CreateDocumentOfOwnership_OwnerRelashionshipDTO DocumentOwnerRelashionship);

        public Task<ClientResponse<GetPlot_DocumentOfOwnershipRelashionshipDTO>> AddPlotDocumentRelashionship(CreatePlot_DocumentOfOwnershipRelashionshipDTO PlotDocumentRelashionship);

        public Task<ClientResponse<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> AddPlotOwnerRelashionship(CreateDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO);

        public Task<ClientResponse<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>>> GetLinkedPlotOwnerRelashionships(List<GetPlotDTO> plots);

        public Task<ClientResponse<HttpResponseMessage>> DeleteRequest(List<GetRequestDTO> requestDTO);

        public Task<ClientResponse<HttpResponseMessage>> DeleteClientRequest(List<GetClientDTO> clientDTOs);

        public Task<ClientResponse<HttpResponseMessage>> DeleteTasks(List<GetTaskDTO> tasks);

        public Task<ClientResponse<HttpResponseMessage>> DeleteActivities(List<GetActivityDTO> tasks);

        public Task<ClientResponse<GetPowerOfAttorneyDocumentDTO>> AddPowerOfAttorney(CreatePowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO);
        public Task<ClientResponse<HttpResponseMessage>> activityPlotRelashionshipRemove(List<GetActivity_PlotRelashionshipDTO> relashionshipDTOs);

        public Task<ClientResponse<HttpResponseMessage>> deletePlotOwnerRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs);


    }
}
