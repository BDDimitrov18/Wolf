using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using MailKit.Net.Imap;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class OwnerService : IOwnerService   
    {
        public IOwnerModelRepository _ownerModelRepository { get; set; }
        public IMapper _mapper { get; set; }

        private readonly IWebSocketService _webSocketService;
        public OwnerService(IOwnerModelRepository ownerModelRepository, IMapper mapper, IWebSocketService webSocketService)
        {
            _mapper = mapper;
            _ownerModelRepository = ownerModelRepository;
            _webSocketService = webSocketService;
        }

        public async Task<GetOwnerDTO> CreateOwner(CreateOwnerDTO ownerDTO) { 
            Owner owner = _mapper.Map<Owner>(ownerDTO);
            await _ownerModelRepository.AddOwner(owner);
            GetOwnerDTO getOwnerDTO = _mapper.Map<GetOwnerDTO>(owner);
            return getOwnerDTO;
        }

        public async Task<GetOwnerDTO> FindOwnerById(int id) {
            Owner owner = await _ownerModelRepository.FindById(id);
            GetOwnerDTO getOwner = _mapper.Map<GetOwnerDTO>(owner); 
            return getOwner;
        }

        public async Task<bool> editOwner(GetOwnerDTO ownerDTO, string clientId) {
            Owner owner = _mapper.Map<Owner>(ownerDTO);
            var updateNotification = new UpdateNotification<GetOwnerDTO>
            {
                OperationType = "Edit",
                EntityType = "GetOwnerDTO",
                UpdatedEntity = ownerDTO
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return await  _ownerModelRepository.EditOwner(owner);
        }

        public async Task<List<GetOwnerDTO>> getAllOwners() { 
            List<Owner> owners = await _ownerModelRepository.getAllOwners();
            List<GetOwnerDTO> ownerDTOs = new List<GetOwnerDTO>();
            foreach (var owner in owners) {
                ownerDTOs.Add(_mapper.Map<GetOwnerDTO>(owner));
            }
            return ownerDTOs;
        }
    }
}
