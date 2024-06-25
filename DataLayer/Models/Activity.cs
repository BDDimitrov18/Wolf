using System;
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

        public int WorkObjectId { get; set; }

        public string ActivityName { get; set; }

        public TimeSpan ExpectedDuration { get; set; }

       
    }
}
