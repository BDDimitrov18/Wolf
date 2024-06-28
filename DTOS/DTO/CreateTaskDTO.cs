﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateTaskDTO
    {

        public int ActivityId { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime StartDate { get; set; }

        public int ExecutantId { get; set; }

        public int? ControlId { get; set; }

        public string? Comments { get; set; }

        public int TaskTypeId { get; set; }
    }
}