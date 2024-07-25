using DataAccessLayer.Models;
using DTOS.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagamentService.Models;
using UserManagamentService.Models.Authentication.Login;
using UserManagamentService.Models.Authentication.SignUp;
using UserManagamentService.Services.Interfaces;
using WolfApi.Models;
using WolfAPI.Services.Interfaces;


namespace WolfApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUserManagament _userManagament;
        private readonly IConfiguration _config;
        private readonly IEmployeeService _employeeService;

        public AuthenticationController(UserManager<ApplicationUser> userManager,
            IConfiguration config,
            IEmailService emailService, 
            IUserManagament userManagament,
            IEmployeeService employeeService)
        {
            _userManager = userManager;
            _config = config;
            _emailService = emailService;
            _userManagament = userManagament;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser) {
            var response = await _userManagament.CreateUserWithTokenAsync(registerUser);

            if (response.IsSuccess)
            {
                var token = response.Response;
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token , email = registerUser.Email }, Request.Scheme);
                var message = new Message(new string[] { registerUser.Email! }, "Confirmation email link", confirmationLink!);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Email Confirmed successfully!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = response.Message });
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            var user = await _userManager.FindByNameAsync(loginUser.Username);
            if (user != null)
            {
                var tokenResponse = await _userManagament.LoginUserWithJwtTokenAsync(loginUser);
                if (tokenResponse.IsSuccess)
                {
                    GetEmployeeDTO employeeDTO = null;
                    if (user.EmployeeId.HasValue)
                    {
                        employeeDTO = await _employeeService.GetEmployeeById(user.EmployeeId.Value);
                    }

                    var jwtTokenResponse = tokenResponse.Response;
                    var response = new TokenResponse
                    {
                        jwtTokenResponse = jwtTokenResponse,
                        employeeDTO = employeeDTO
                    };

                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status401Unauthorized, new Response { Status = "Error", Message = tokenResponse.Message });
            }
            return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "User not found" });
        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Email Confirmed successfully!" });
                }

            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Internally" });
        }
       
    }
}
