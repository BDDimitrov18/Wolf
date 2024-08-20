using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetRequestDTO
    {
        public int RequestId { get; set; }
        public float Price { get; set; }

        public string PaymentStatus { get; set; }

        public float Advance { get; set; }

        public string? Comments { get; set; }

        public string RequestName { get; set; }
        public string? Path { get; set; }

        public string? PlotsInfo { get; set; }

        public int? RequestCreatorId { get; set; }

        public GetEmployeeDTO? RequestCreator { get; set; }

        

    }
}
