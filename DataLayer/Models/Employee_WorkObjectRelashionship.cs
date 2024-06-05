using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Employee_WorkObjectRelashionship
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }
    }
}
