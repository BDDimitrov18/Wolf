using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WolfAPI.DTO;

namespace WolfApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet("Employees")]

        public IEnumerable<Employee> GetEmployees(){
            return new Employee[] { null };            
        }

        //public async Task<bool> CreateEmployee([FromBody] CreateEmployeeDTO employeeDTO) { 
            
        //}
    }
}
