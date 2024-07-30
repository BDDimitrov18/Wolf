using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateInvoiceDTO
    {
        public string number { get; set; }
        public int RequestId { get; set; }
        public float Sum { get; set; }
    }
}
