﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetRequestDTO
    {
        public int RequestId { get; set; }
        public float Price { get; set; }

        public string PaymentStatus { get; set; }

        public float Advance { get; set; }

        public string? Comments { get; set; }
    }
}
