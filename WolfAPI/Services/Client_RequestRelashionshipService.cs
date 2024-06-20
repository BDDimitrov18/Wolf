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
            foreach (var clientDTO in clientDTOs)
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
    }
}
