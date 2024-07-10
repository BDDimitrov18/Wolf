using DTOS.DTO;

namespace WolfAPI.Services.Interfaces
{
    public interface IFileService
    {
        public Task CreateFile(CreateFileDTO fileDTO);
    }
}
