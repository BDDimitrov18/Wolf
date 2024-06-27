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

    }
}
