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


namespace WolfApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUserManagament _userManagament;
        private readonly IConfiguration _config;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            IConfiguration config,
            IEmailService emailService, 
            IUserManagament userManagament)
        {
            _userManager = userManager;
            
            _config = config;
            _emailService = emailService;
            _userManagament = userManagament;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser) {
            var token = await _userManagament.CreateUserWithTokenAsync(registerUser);

            if (token.IsSuccess)
            {
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = registerUser.Email }, Request.Scheme);
                var message = new Message(new string[] { registerUser.Email! }, "Confirmation email link", confirmationLink!);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Email Confirmed successfully!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = token.Message });
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser) 
        {
            var tokenResponse =  await _userManagament.LoginUserWithJwtTokenAsync(loginUser);

            if (tokenResponse.IsSuccess)
            {
                return Ok(tokenResponse.Response);
            }

            return StatusCode(StatusCodes.Status401Unauthorized, new Response { Status = "Error", Message = tokenResponse.Message });
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
