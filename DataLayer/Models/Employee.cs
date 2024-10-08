﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string phone { get; set; }

        public string Email { get; set; }

        public bool Outsider { get; set; }

        public ICollection<starRequest_EmployeeRelashionship> Request_EmployeeRelashionships { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
