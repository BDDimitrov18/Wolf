using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using WolfAPI.Services;
using WolfAPI.Services.Interfaces;
using DTOS.DTO;
using System.IdentityModel.Tokens.Jwt;

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
            var token = GetJwtTokenFromRequest();
            var clientId = GetClientIdFromJwt(token);
            return await _employeeService.Add(employeeDTO,clientId);
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
            var clientId = jsonToken.Claims.First(claim => claim.Type == "sub").Value; // Assuming "sub" is used for client ID
            return clientId;
        }
    }
}
