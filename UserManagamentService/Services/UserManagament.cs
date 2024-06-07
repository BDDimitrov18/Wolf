using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

namespace UserManagamentService.Services
{
    public class UserManagament : IUserManagament
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public UserManagament(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResponse<object>> LoginUserWithJwtTokenAsync(LoginUser loginUser)
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


                return new ApiResponse<object> { IsSuccess = true, StatusCode = 200, Message = $"Token Created", Response = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                }};
                
            }
            else
            {
                return new ApiResponse<object> { IsSuccess = false, StatusCode = 401, Message = "Unauthorized" };
            }
        }

        public async Task<ApiResponse<string>> CreateUserWithTokenAsync(RegisterUser registerUser)
        {
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);

            if (userExist != null)
            {
                return new ApiResponse<string> { IsSuccess = false, StatusCode = 403, Message = "User Already Exist" };
            }

            IdentityUser user = new()
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

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

            var token = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

                );
            return token;
        }
    }
}
