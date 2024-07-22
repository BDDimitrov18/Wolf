using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class RequestService: IRequestService
    {
        private readonly IRequestModelRepository _requestRepository;
        private readonly IClientModelRepository _clientRepository;
        private readonly IActivityModelRespository _activityModelRespository;
        private readonly IPlotModelRepository _plotModelRepository;
        private readonly IAcitvityService _acitvityService;
        private readonly IClient_RequestRelashionshipService _client_requestRelashionshipService;
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public RequestService(IRequestModelRepository requestRepository, IMapper mapper, IClientModelRepository clientRepository,
        IActivityModelRespository activityModelRespository, IPlotModelRepository plotModelRepository, IClient_RequestRelashionshipService client_requestRelashionshipService,
        IAcitvityService acitvityService, IWebSocketService webSocketService)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _clientRepository = clientRepository;
            _activityModelRespository = activityModelRespository;
            _plotModelRepository = plotModelRepository;
            _client_requestRelashionshipService = client_requestRelashionshipService;
            _acitvityService = acitvityService;
            _webSocketService = webSocketService;
        }

        public async Task<List<RequestWithClientsDTO>> GetLinked(List<GetRequestDTO> requestsDTO)
        {
            List<RequestWithClientsDTO> requestWithClientsDTOs = new List<RequestWithClientsDTO>();
            foreach (var requestDTO in requestsDTO)
            {
                List<Client> clients = _clientRepository.GetLinked(_mapper.Map<Request>(requestDTO));
                List<Activity> activities = _activityModelRespository.FindLinkedActivity(_mapper.Map<Request>(requestDTO));
                
                List<GetClientDTO> getClientDTOs = new List<GetClientDTO>();
                List<GetActivityDTO> getActivityDTOs = new List<GetActivityDTO>();
                foreach (Client client in clients)
                {
                    getClientDTOs.Add(_mapper.Map<GetClientDTO>(client));
                }
                foreach (Activity activity in activities) {
                    getActivityDTOs.Add(_mapper.Map<GetActivityDTO>(activity));
                }
                foreach (var activityDto in getActivityDTOs) {
                    List<Plot> plots = await _plotModelRepository.GetLinkedPlotsToActivty(activityDto.ActivityId);
                    List<GetPlotDTO> plotDTOs = new List<GetPlotDTO>();
                    foreach (var plot in plots) {
                        plotDTOs.Add(_mapper.Map<GetPlotDTO>(plot));
                    }
                    activityDto.Plots = plotDTOs;
                }

                RequestWithClientsDTO requestLink = new RequestWithClientsDTO()
                {
                    requestDTO = requestDTO,
                    clientDTOs = getClientDTOs,
                    activityDTOs = getActivityDTOs
                };
                requestWithClientsDTOs.Add(requestLink);
            }
            
            return requestWithClientsDTOs;
        }

        public async Task<List<GetRequestDTO>> Add(List<CreateRequestDTO> requestsDto,string clientId)
        {
            List<GetRequestDTO> returnList = new List<GetRequestDTO>();
            List<Request> requests = new List<Request>();
            foreach (var requestDTO in requestsDto) { 
                var request = _mapper.Map<Request>(requestDTO);
                requests.Add(request);
            }
            
            _requestRepository.Add(requests);
            foreach (var request in requests)
            {
                var requestDTO = _mapper.Map<GetRequestDTO>(request);
                returnList.Add(requestDTO); 
            }

            var updateNotification = new UpdateNotification<List<GetRequestDTO>>
            {
                OperationType = "Create",
                EntityType = "List<GetRequestDTO>",
                UpdatedEntity = returnList
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return returnList;
        }

        public List<GetRequestDTO> GetAllRequest()
        {
            var requestsList = _requestRepository.GetAll();
            List<GetRequestDTO> createRequestsDTOs = new List<GetRequestDTO>();
            foreach (var request in requestsList)
            {
                var requestDTO = _mapper.Map<GetRequestDTO>(request);
                createRequestsDTOs.Add(requestDTO);
            }
            return createRequestsDTOs;
        }

        public async Task<bool> Delete(List<GetRequestDTO> requestDTOs, string clientId)
        {
            List<Request> requests = new List<Request>();
            bool allDeletionsSuccessful = true;

            foreach (var requestDTO in requestDTOs)
            {
                var request = _mapper.Map<Request>(requestDTO);
                requests.Add(request);

                bool activityDeletionSuccess = await _acitvityService.DeleteOnRequest(request);
                if (!activityDeletionSuccess)
                {
                    // Log the failure for deleting activities
                    // Example: _logger.LogError($"Failed to delete activities for request ID {request.RequestId}");
                    allDeletionsSuccessful = false;
                }

                bool clientRequestDeletionSuccess = await _client_requestRelashionshipService.OnRequestDelete(request, clientId);
                if (!clientRequestDeletionSuccess)
                {
                    // Log the failure for deleting client request relationships
                    // Example: _logger.LogError($"Failed to delete client request relationships for request ID {request.RequestId}");
                    allDeletionsSuccessful = false;
                }
            }

            bool requestDeletionSuccess = await _requestRepository.Delete(requests);
            if (!requestDeletionSuccess)
            {
                // Log the failure for deleting requests
                // Example: _logger.LogError("Failed to delete requests");
                allDeletionsSuccessful = false;
            }
            else {
                var updateNotification = new UpdateNotification<List<GetRequestDTO>>
                {
                    OperationType = "Delete",
                    EntityType = "List<GetRequestDTO>",
                    UpdatedEntity = requestDTOs
                };
                await _webSocketService.SendMessageToRolesAsync(updateNotification,clientId, "admin", "user");
            }

            return allDeletionsSuccessful;
        }
    }
}
