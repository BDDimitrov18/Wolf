using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.DTO;
using Wolf.Models;

namespace WolfClient.Services.Interfaces
{
    public interface IApiClient
    {
       void SetToken(string token);
        public Task<ClientResponse<TokenResponse>> GetJwtToken(LoginUserDto loginUser);

        bool getLoginStatus();
    }

}
