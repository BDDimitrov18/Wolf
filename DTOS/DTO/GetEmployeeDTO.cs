using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        private string _fullName = "";

        public bool Outsider { get; set; }

        public string FullName
        {
            get
            {
                if (_fullName == "")
                {
                    return $"{FirstName} {SecondName ?? ""} {LastName}".Replace(" ", " ").Trim();
                }
                else
                {
                    return _fullName;
                }
            }
            set
            {
                    _fullName = value;
            }
        }
    }
}
