using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class starRequest_EmployeeRelashionship
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
