using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        public string RequestName { get; set; }

        public float Price { get; set; }

        public string PaymentStatus { get; set; }

        public float Advance { get; set; }

        public string? Comments { get; set; }

        public ICollection<Request_PlotRelashionship> request_PlotRelashionships { get; set; }
        public ICollection<Client_RequestRelashionship> Client_RequestRelationships { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
