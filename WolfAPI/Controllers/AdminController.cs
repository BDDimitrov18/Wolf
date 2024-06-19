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
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]

    
    public class AdminController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public AdminController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees")]

        public  IEnumerable<GetEmployeeDTO> GetAllEmployees(){
            return  _employeeService.GetAllEmployees();         
        }
        [HttpPost("CreateEmployee")]
        public void CreateEmployee([FromBody] CreateEmployeeDTO employeeDTO) {
            _employeeService.Add(employeeDTO);
        }
    }
}
