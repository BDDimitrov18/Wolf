using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class Client_RequestRelashionshipService : IClient_RequestRelashionshipService
    {
        private readonly IClient_RequestRelashionshipModelRepository _client_RequestRelashionshipModelRepository;
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public Client_RequestRelashionshipService(IClient_RequestRelashionshipModelRepository client_RequestRelashionshipModelRepository, IMapper mapper, IWebSocketService webSocketService)
        {
            _client_RequestRelashionshipModelRepository = client_RequestRelashionshipModelRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
        }

        public async Task<List<GetClient_RequestRelashionshipDTO>> CreateClient_RequestRelashionship(GetRequestDTO requestDTO, List<GetClientDTO> clientDTOs)
        {
            var request = _mapper.Map<Request>(requestDTO);
            List<Client> clients = new List<Client>();
            foreach (GetClientDTO clientDTO in clientDTOs)
            {
                var client = _mapper.Map<Client>(clientDTO);
                clients.Add(client);
            }
            List<GetClient_RequestRelashionshipDTO> client_RequestRelashionshipsDTOs = new List<GetClient_RequestRelashionshipDTO>();
            List<Client_RequestRelashionship> resultSet = _client_RequestRelashionshipModelRepository.Add(request, clients);
            foreach(var result in resultSet)
            {
                var getClient_RequestRelashionshipDTO = _mapper.Map<GetClient_RequestRelashionshipDTO>(result);
                client_RequestRelashionshipsDTOs.Add(getClient_RequestRelashionshipDTO);
            }

            var updateNotification = new UpdateNotification<List<GetClient_RequestRelashionshipDTO>>
            {
                OperationType = "Create",
                UpdatedEntity = client_RequestRelashionshipsDTOs
            };

            await _webSocketService.SendMessageToAllAsync(updateNotification);

            return client_RequestRelashionshipsDTOs;
        }

        public async Task<bool> OnRequestDelete(Request request)
        {
            try
            {
                List<Client_RequestRelashionship> client_RequestRelashionships = new List<Client_RequestRelashionship>();
                // Attempt to delete client request relationships for the request
                bool clientRequestDeletionSuccess = await _client_RequestRelashionshipModelRepository.OnRequestDeleteAsync(request, client_RequestRelashionships);
                if (!clientRequestDeletionSuccess)
                {
                    // Log the failure
                    // Example: _logger.LogError($"Failed to delete client request relationships for request ID {request.RequestId}");
                    return false;
                }
                else {
                    List<GetClient_RequestRelashionshipDTO> getClient_RequestRelashionshipDTOs = new List<GetClient_RequestRelashionshipDTO>();

                    foreach (var relashionship in client_RequestRelashionships) {
                        getClient_RequestRelashionshipDTOs.Add(_mapper.Map<GetClient_RequestRelashionshipDTO>(relashionship));
                    }

                    var updateNotification = new UpdateNotification<List<GetClient_RequestRelashionshipDTO>>
                    {
                        OperationType = "Delete",
                        UpdatedEntity = getClient_RequestRelashionshipDTOs
                    };

                    await _webSocketService.SendMessageToAllAsync(updateNotification);
                }

                // If the deletion was successful, return true
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                // Example: _logger.LogError(ex, $"An error occurred while deleting client request relationships for request ID {request.RequestId}");

                // Return false to indicate failure
                return false;
            }
        }

        public async Task<bool> OnClientsDelete(List<GetClientDTO> clientsDTOs)
        {
            List<Client> clients = new List<Client>();

            // Map each DTO to a Client object
            foreach (var clientDTO in clientsDTOs)
            {
                clients.Add(_mapper.Map<Client>(clientDTO));
            }

            var updateNotification = new UpdateNotification<List<GetClientDTO>>
            {
                OperationType = "Delete",
                UpdatedEntity = clientsDTOs
            };

            await _webSocketService.SendMessageToAllAsync(updateNotification);

            // Call the repository method to delete the clients
            return await _client_RequestRelashionshipModelRepository.OnDeleteClients(clients);
        }
    }
}
