using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class PowerOfAttorneyDocumentService : IPowerOfAttorneyDocumentService
    {
        private IPowerOfAttorneyModelRepository _powerOfattorneyModelRepository { get; set; }
        private IMapper _mapper { get; set; }

        private readonly IWebSocketService _webSocketService;

        public PowerOfAttorneyDocumentService(IPowerOfAttorneyModelRepository powerOfattorneyModelRepository, IMapper mapper, IWebSocketService webSocketService)
        {
            _powerOfattorneyModelRepository = powerOfattorneyModelRepository;
            _mapper = mapper;
            _webSocketService = webSocketService;
        }

        public async Task<GetPowerOfAttorneyDocumentDTO> createPowerOfAttorneyDocument(CreatePowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO) {
            var powerOfattorney = _mapper.Map<PowerOfAttorneyDocument>(powerOfAttorneyDocumentDTO);
            await _powerOfattorneyModelRepository.CreatePowerOfAttorney(powerOfattorney);
            return _mapper.Map<GetPowerOfAttorneyDocumentDTO>(powerOfattorney); 
        }

        public async Task<bool> EditPowerOfAttorneyDocument(GetPowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO, string clientId) {
            PowerOfAttorneyDocument document = _mapper.Map<PowerOfAttorneyDocument>(powerOfAttorneyDocumentDTO);
            var updateNotification = new UpdateNotification<GetPowerOfAttorneyDocumentDTO>
            {
                OperationType = "Edit",
                EntityType = "GetPowerOfAttorneyDocumentDTO",
                UpdatedEntity = powerOfAttorneyDocumentDTO
            };
            await _webSocketService.SendMessageToRolesAsync(updateNotification, clientId, "admin", "user");
            return await _powerOfattorneyModelRepository.EditPowerOfAttorney(document);
        }
    }
}
