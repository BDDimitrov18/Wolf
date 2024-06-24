using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateRequestDTO
    {

        public float Price { get; set; }

        public string PaymentStatus { get ; set; }

        public float Advance { get; set; }

        public string? Comments { get; set; }

        public string RequestName { get; set; }
    }
}
