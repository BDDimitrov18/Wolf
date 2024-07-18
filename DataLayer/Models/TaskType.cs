using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TaskType
    {
        [Key]
        public int TaskTypeId { get; set; }

        public string TaskTypeName { get; set; }

        public int ActivityTypeID { get; set; }

        public ActivityType Activity { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
