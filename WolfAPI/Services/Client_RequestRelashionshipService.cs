﻿using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using System.Collections.Generic;
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

        public async Task<List<GetClient_RequestRelashionshipDTO>> CreateClient_RequestRelashionship(GetRequestDTO requestDTO, List<GetClientDTO> clientDTOs, string clientId)
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
                EntityType = "List<GetClient_RequestRelashionshipDTO>",
                UpdatedEntity = client_RequestRelashionshipsDTOs
            };

            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");

            return client_RequestRelashionshipsDTOs;
        }

        public async Task<bool> OnRequestDelete(Request request,string clientId)
        {
            try
            {
                List<Client_RequestRelashionship> client_RequestRelashionships = new List<Client_RequestRelashionship>();
                // Attempt to delete client request relationships for the request
                bool clientRequestDeletionSuccess = await _client_RequestRelashionshipModelRepository.OnRequestDeleteAsync(request);
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
                        EntityType = "List<GetClient_RequestRelashionshipDTO>",
                        UpdatedEntity = getClient_RequestRelashionshipDTOs
                    };

                    await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
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
        //!!!!!!!!!!!!!!!!!!!!!! FIX IT HERE THE LOGIC. BEFORE THE FIRST ARGUMENT WAS GETCLIENTDTO FIX THE LOGIC
        public async Task<bool> OnClientsDelete(List<GetClient_RequestRelashionshipDTO> clientsDTOs, string clientId)
        {
            List<Client_RequestRelashionship> client_RequestRelashionships = new List<Client_RequestRelashionship>();
            foreach (var relashionship in clientsDTOs) {
                client_RequestRelashionships.Add(_mapper.Map<Client_RequestRelashionship>(relashionship));
            }



            // Call the repository method to delete the clients
            List<Client_RequestRelashionship> getClient_RequestRelashionshipDTOs = new List<Client_RequestRelashionship>();
            var returnBool =  await _client_RequestRelashionshipModelRepository.OnDeleteClients(client_RequestRelashionships);

            if (returnBool)
            {
                var updateNotification = new UpdateNotification<List<GetClient_RequestRelashionshipDTO>>
                {
                    OperationType = "Delete",
                    EntityType = "List<GetClient_RequestRelashionshipDTO>",
                    UpdatedEntity = clientsDTOs
                };
                await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            }

            return returnBool;
        }
    }
}
