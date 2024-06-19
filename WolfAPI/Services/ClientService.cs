﻿using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientModelRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientModelRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public void AddClient(CreateClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            _clientRepository.Add(client);
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