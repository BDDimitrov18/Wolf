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
        private readonly IMapper _mapper;

        public Client_RequestRelashionshipService(IClient_RequestRelashionshipModelRepository client_RequestRelashionshipModelRepository, IMapper mapper)
        {
            _client_RequestRelashionshipModelRepository = client_RequestRelashionshipModelRepository;
            _mapper = mapper;
        }

        public List<GetClient_RequestRelashionshipDTO> CreateClient_RequestRelashionship(GetRequestDTO requestDTO, List<GetClientDTO> clientDTOs)
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
            return client_RequestRelashionshipsDTOs;
        }

        public async Task<bool> OnRequestDelete(Request request)
        {
            try
            {
                // Attempt to delete client request relationships for the request
                bool clientRequestDeletionSuccess = await _client_RequestRelashionshipModelRepository.OnRequestDeleteAsync(request);
                if (!clientRequestDeletionSuccess)
                {
                    // Log the failure
                    // Example: _logger.LogError($"Failed to delete client request relationships for request ID {request.RequestId}");
                    return false;
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

            // Call the repository method to delete the clients
            return await _client_RequestRelashionshipModelRepository.OnDeleteClients(clients);
        }
    }
}
