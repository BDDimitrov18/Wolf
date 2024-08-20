using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.ViewModels
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }

        public string PaymentStatus { get; set; }


        public string? Comments { get; set; }

        public string RequestName { get; set; }

        public string PlotsInfo { get; set; }
    }
}
