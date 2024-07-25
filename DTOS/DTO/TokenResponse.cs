using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class TokenResponse
    {
        public JwtTokenResponse jwtTokenResponse { get; set; }

        public GetEmployeeDTO employeeDTO { get; set; }
    }
}
