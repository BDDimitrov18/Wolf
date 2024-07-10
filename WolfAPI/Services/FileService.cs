using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Services
{
    public class FileService : IFileService
    {
        private readonly IFileModelRepository _fileModelRepository;
        private readonly IMapper _mapper;

        public FileService(IFileModelRepository fileModelRepository, IMapper mapper) 
        {
            _fileModelRepository = fileModelRepository;
            _mapper = mapper;
        }

        public async Task CreateFile(CreateFileDTO fileDTO) {
            Files file = _mapper.Map<Files>(fileDTO);
            await _fileModelRepository.CreateFile(file);
        }
    }
}
