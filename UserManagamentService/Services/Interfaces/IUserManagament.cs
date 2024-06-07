using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagamentService.Models;
using UserManagamentService.Models.Authentication.Login;
using UserManagamentService.Models.Authentication.SignUp;

namespace UserManagamentService.Services.Interfaces
{
    public interface IUserManagament
    {
        Task<ApiResponse<string>> CreateUserWithTokenAsync(RegisterUser registerUser);
        Task<ApiResponse<object>> LoginUserWithJwtTokenAsync(LoginUser loginUSer);
    }
}
