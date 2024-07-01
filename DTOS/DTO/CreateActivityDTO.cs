﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateActivityDTO
    {
        public int RequestId { get; set; }

        public int ActivityTypeID { get; set; }

        public int? ParentActivityId { get; set; }

        public DateTime ExpectedDuration { get; set; }

    }
}
