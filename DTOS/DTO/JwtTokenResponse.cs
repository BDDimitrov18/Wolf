using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class JwtTokenResponse
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public string[] role { get; set; }
    }
}
