using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Request_PlotRelashionship
    {
        public int requestId { get; set; }
        public Request Request { get; set; }

        public int plotId { get; set; }
        public Plot plot { get; set; }
    }
}
