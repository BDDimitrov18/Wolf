using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Models;

namespace WolfClient.Services.Interfaces
{
    public interface IFileUploader
    {
        public void SetToken(string token);

        public Task<ClientResponse<HttpResponseMessage>> UploadFileAsync(string filePath);
        public Task<ClientResponse<byte[]>> DownloadFileContentAsync(GetFileDTO getFileDTO);

        public Task<List<GetFileDTO>> GetAllFilesAsync();
    }
}
