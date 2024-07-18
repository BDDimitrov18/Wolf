using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

        public float Sum { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
