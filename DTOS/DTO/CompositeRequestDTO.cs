using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CompositeRequestDTO
    {
        public GetRequestDTO RequestDTO { get; set; }
        public List<GetClientDTO> ClientsList { get; set; }
    }
}
