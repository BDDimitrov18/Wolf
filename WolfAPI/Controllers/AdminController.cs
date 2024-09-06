using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using WolfAPI.Services;
using WolfAPI.Services.Interfaces;
using DTOS.DTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using UserManagamentService.Services.Interfaces;
using WolfAPI.Models;

namespace WolfApi.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]

    
    public class AdminController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserManagament _userManagament;
        public AdminController(IEmployeeService employeeService, UserManager<ApplicationUser> userManager
        , IUserManagament userManagament)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _userManagament = userManagament;
        }

        
        [HttpPost("CreateEmployee")]
        public async Task<List<GetEmployeeDTO>> CreateEmployee([FromBody]List<CreateEmployeeDTO> employeeDTO) {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _employeeService.Add(employeeDTO,clientId);
        }

        [HttpPost("link-employee")]
        public async Task<IActionResult> LinkEmployeeToUser([FromBody] LinkEmployeeModel linkEmployeeModel )
        {
            var result = await _userManagament.LinkEmployeeToUserAsync(linkEmployeeModel.UserId, linkEmployeeModel.EmployeeId);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpPost("EditEmployee")]
        public async Task<IActionResult> EditEmployee([FromBody] GetEmployeeDTO employee)
        {
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            bool result = await _employeeService.EditEmployee(employee, clientId);

            if (result)
            {
                return Ok(employee); // Return the updated employee DTO with HTTP 200 OK status
            }
            else
            {
                return NotFound(); // Return HTTP 404 Not Found if the employee was not found
            }
        }
        private string GetJwtTokenFromRequest()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();
            return authHeader.Replace("Bearer ", string.Empty);
        }

        private string GetClientIdFromJwt(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken == null)
            {
                throw new InvalidOperationException("Invalid JWT token.");
            }

            var clientIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "jti");
            if (clientIdClaim == null)
            {
                throw new InvalidOperationException("Client ID claim not found in JWT token.");
            }

            return clientIdClaim.Value;
        }
    }
}
