﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.DTO;
using Wolf.Models;

namespace Wolf.Services.Interfaces
{
    public interface IApiClient
    {
       void SetToken(string token);
       Task<ClientResponse<string>> GetJwtToken(LoginUserDto loginUser);
    }

}
