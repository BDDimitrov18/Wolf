using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ActivityType
    {
        [Key]
        public int ActivityTypeID { get; set; }

        public string ActivityTypeName { get; set; }

        public ICollection<TaskType> TaskTypes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
