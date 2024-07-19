using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using WolfAPI.Services;
using WolfAPI.Services.Interfaces;
using DTOS.DTO;

namespace WolfApi.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]

    
    public class AdminController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public AdminController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        
        [HttpPost("CreateEmployee")]
        public async Task<List<GetEmployeeDTO>> CreateEmployee([FromBody]List<CreateEmployeeDTO> employeeDTO) {
            return await _employeeService.Add(employeeDTO);
        }
    }
}
