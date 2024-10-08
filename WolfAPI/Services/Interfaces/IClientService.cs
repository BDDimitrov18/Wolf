﻿using DataAccessLayer.Models;
using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IClientService
    {
        public Task<List<GetClientDTO>> AddClient(List<CreateClientDTO> clientDTOs, string clientId);

        public IEnumerable<GetClientDTO> GetAllClients();

        public Task<bool> EditClient(GetClientDTO clientDTO, string clientId);

    }
}
