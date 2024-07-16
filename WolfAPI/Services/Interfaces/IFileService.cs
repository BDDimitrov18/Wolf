using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IFileService
    {
        public Task CreateFile(CreateFileDTO fileDTO);

        public List<GetFileDTO> GetAllFiles();
        public Task<GetFileDTO> getFilePath(GetFileDTO file);
    }
}
