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

        public OwnerService(IOwnerModelRepository ownerModelRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ownerModelRepository = ownerModelRepository;
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

        public async Task<bool> editOwner(GetOwnerDTO ownerDTO) {
            Owner owner = _mapper.Map<Owner>(ownerDTO); 
            return await  _ownerModelRepository.EditOwner(owner);
        }
    }
}
