using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetClient_RequestRelashionshipDTO
    {
        public int RequestId { get; set; }
        public GetRequestDTO Request { get; set; }

        public int ClientId { get; set; }
        public GetClientDTO Client { get; set; }

        public string? OwnershipType { get; set; }
    }
}
