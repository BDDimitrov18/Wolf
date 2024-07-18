using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using System.Collections.Generic;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientModelRepository _clientRepository;
        private readonly IWebSocketService _webSocketService;
        private readonly IMapper _mapper;

        public ClientService(IClientModelRepository clientRepository, IMapper mapper, IWebSocketService webSocketService)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
        }
        public async Task<List<GetClientDTO>> AddClient(List<CreateClientDTO> clientDTOs)
        {
            List<GetClientDTO> returnList = new List<GetClientDTO>();
            List<Client> clients = new List<Client>();
            foreach (var clientDTO in clientDTOs)
            {
                var client = _mapper.Map<Client>(clientDTO);
                clients.Add(client);
            }

            _clientRepository.Add(clients);

            foreach (var client in clients)
            {
                var clientDTO = _mapper.Map<GetClientDTO>(client);
                returnList.Add(clientDTO);
            }

            var updateNotification = new UpdateNotification<List<GetClientDTO>>
            {
                OperationType = "Create",
                UpdatedEntity = returnList
            };

            await _webSocketService.SendMessageToAllAsync(updateNotification);

            return returnList;
            
        }

        public IEnumerable<GetClientDTO> GetAllClients() { 
            var clientsList =  _clientRepository.GetAll();
            List<GetClientDTO> createClientDTOs = new List<GetClientDTO>();
            foreach (var client in clientsList) {
                var clientDTO = _mapper.Map<GetClientDTO>(client);
                createClientDTOs.Add(clientDTO);
            } 

            return createClientDTOs;
        }

        
    }
}
