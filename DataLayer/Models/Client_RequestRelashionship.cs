using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Client_RequestRelashionship
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public string? OwnershipType { get; set; }
    }
}
