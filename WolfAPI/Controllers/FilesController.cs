using DTOS.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WolfAPI.Controllers
{
    [Authorize(Roles = "admin,user")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var filePath = Path.Combine("C:\\Users\\dell\\Documents\\FilesForWolf\\", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            CreateFileDTO createFileDTO = new CreateFileDTO() { 
                FileName = file.FileName,
                FilePath = filePath,
                UploadedAt = DateTime.UtcNow,
            };


            return Ok("File uploaded successfully.");
        }
    }
}
