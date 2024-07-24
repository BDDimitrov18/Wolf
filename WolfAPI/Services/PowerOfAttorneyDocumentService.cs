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

        public PowerOfAttorneyDocumentService(IPowerOfAttorneyModelRepository powerOfattorneyModelRepository, IMapper mapper)
        {
            _powerOfattorneyModelRepository = powerOfattorneyModelRepository;
            _mapper = mapper;
        }

        public async Task<GetPowerOfAttorneyDocumentDTO> createPowerOfAttorneyDocument(CreatePowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO) {
            var powerOfattorney = _mapper.Map<PowerOfAttorneyDocument>(powerOfAttorneyDocumentDTO);
            await _powerOfattorneyModelRepository.CreatePowerOfAttorney(powerOfattorney);
            return _mapper.Map<GetPowerOfAttorneyDocumentDTO>(powerOfattorney); 
        }

        public async Task<bool> EditPowerOfAttorneyDocument(GetPowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO) {
            PowerOfAttorneyDocument document = _mapper.Map<PowerOfAttorneyDocument>(powerOfAttorneyDocumentDTO);
            return await _powerOfattorneyModelRepository.EditPowerOfAttorney(document);
        }
    }
}
