﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int ActivityTypeID { get; set; }
        public ActivityType ActivityType { get; set; }

        public DateTime ExpectedDuration { get; set; }

        public int? ParentActivityId { get; set; }
        public Activity? ParentActivity { get; set; }

        public ICollection<WorkTask> Tasks { get; set; }

        public ICollection<Activity_PlotRelashionship> ActivityPlots { get; set; }
    }
}
