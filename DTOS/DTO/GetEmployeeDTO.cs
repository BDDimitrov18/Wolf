using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetEmployeeDTO
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string phone { get; set; }

        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {SecondName ?? ""} {LastName}".Replace(" ", " ").Trim();
            }
        }
    }
}
