using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using DTOS.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagamentService.Models;
using UserManagamentService.Models.Authentication.Login;
using UserManagamentService.Models.Authentication.SignUp;
using UserManagamentService.Services.Interfaces;
using WolfClient;

namespace UserManagamentService.Services
{
    public class UserManagament : IUserManagament
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmployeeModelRepository _employeeModelRepository;
        private readonly IConfiguration _config;

        public UserManagament(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config, IEmployeeModelRepository employeeModelRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
            _employeeModelRepository = employeeModelRepository;
        }

        public async Task<ApiResponse<JwtTokenResponse>> LoginUserWithJwtTokenAsync(LoginUser loginUser)
        {
            var user = await _userManager.FindByNameAsync(loginUser.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginUser.Password) && user.EmailConfirmed)
            {
                var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var jwtToken = GetToken(authClaims);

                var jwtTokenResponse = new JwtTokenResponse
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo,
                    role = userRoles.ToArray()
                };

                return new ApiResponse<JwtTokenResponse>
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Token Created",
                    Response = jwtTokenResponse
                };
            }
            else
            {
                return new ApiResponse<JwtTokenResponse> { IsSuccess = false, StatusCode = 401, Message = "Unauthorized" };
            }
        }

        public async Task<ApiResponse<string>> CreateUserWithTokenAsync(RegisterUser registerUser)
        {
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);

            if (userExist != null)
            {
                return new ApiResponse<string> { IsSuccess = false, StatusCode = 403, Message = "User Already Exist" };
            }

            ApplicationUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.username,
            };

            if (await _roleManager.RoleExistsAsync(registerUser.Role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);

                if (!result.Succeeded)
                {
                    return new ApiResponse<string> { IsSuccess = false, StatusCode = 403, Message = "User could not be created" };
                }

                await _userManager.AddToRoleAsync(user, registerUser.Role);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                


                return new ApiResponse<string> { IsSuccess = true, StatusCode = 200, Message = $"User created and email sent to {registerUser.Email} successfully!", Response = token };
            }
            else
            {
                return new ApiResponse<string> { IsSuccess = false, StatusCode = 500, Message = $"Role Does not exist!" };
            }
        }

        public async Task<ApiResponse<object>> LinkEmployeeToUserAsync(string userId, int employeeId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ApiResponse<object> { IsSuccess = false, StatusCode = 404, Message = "User not found" };
            }

            var employee = await _employeeModelRepository.Get(employeeId);
            if (employee == null)
            {
                return new ApiResponse<object> { IsSuccess = false, StatusCode = 404, Message = "Employee not found" };
            }

            user.EmployeeId = employeeId;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new ApiResponse<object> { IsSuccess = true, StatusCode = 200, Message = "Employee linked to user successfully." };
            }

            return new ApiResponse<object> { IsSuccess = false, StatusCode = 500, Message = "Failed to link employee to user." };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

            var token = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    expires: TimeSettingsUserManagament.GetCurrentTime().AddHours(4),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

                );
            return token;
        }
    }
}
