using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class WorkTask
    {
        [Key]
        public int TaskId { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime StartDate { get; set; }

        public int ExecutantId { get; set; }
        public Employee Executant { get; set; }

        public int? ControlId { get; set; }
        public Employee? Control { get; set; }

        public string? Comments { get; set; }

        public int TaskTypeId { get; set; }
        public TaskType taskType { get; set; }

    }
}
