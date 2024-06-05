using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Request_WorkObjectRelashionship
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }
    }
}
