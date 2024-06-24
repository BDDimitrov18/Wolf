using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class RequestWithClientsDTO
    {
        public GetRequestDTO requestDTO { get; set; }

        public List<GetClientDTO> clientDTOs { get; set; }
    }
}
