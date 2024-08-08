using DTOS.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WolfAPI.Services.Interfaces;

namespace WolfAPI.Controllers
{
    [Authorize(Roles = "admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            string currentDirectory = Directory.GetCurrentDirectory();

            // Combine the current directory with the file name
            var filePath = Path.Combine(currentDirectory, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            CreateFileDTO createFileDTO = new CreateFileDTO() { 
                FileName = file.FileName,
                FilePath = filePath,
                UploadedAt = DateTime.UtcNow,
            };

            await _fileService.CreateFile(createFileDTO);

            return Ok("File uploaded successfully.");
        }

        [HttpPost("download")]

        public async Task<IActionResult> DownloadFile([FromBody] GetFileDTO getFileDTO)
        {
            if (getFileDTO == null)
            {
                return BadRequest("Invalid request payload");
            }

            var file = await _fileService.getFilePath(getFileDTO);
            if (file == null)
            {
                return NotFound("File not found");
            }

            var filePath = file.FilePath;
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found on server");
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "application/octet-stream", file.FileName);
        }

        [HttpPost("GetAllFiles")]
        public  List<GetFileDTO> getAllFiles() { 
            return _fileService.GetAllFiles();
        }
    }
}
