﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateStarRequest_EmployeeRelashionshipDTO
    {
        public int RequestId { get; set; }
        public int EmployeeID { get; set; }

        public string StarColor { get; set; }
    }
}
