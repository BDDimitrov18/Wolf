using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.ViewModels
{
    public class ActivityViewModel
    {
        public string ActivityTypeName { get; set; }
        public int ActivityId { get; set; }
        public string TaskTypeName { get; set; }
        public int TaskId { get; set; }
        public string ExecutantFullName { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string ControlFullName { get; set; }
        public string Comments { get; set; }
        public string Identities { get; set; }
        public string ParentActivity { get; set; }
        public string tax { get; set; }
        public string taxComment { get; set; }

        public string Status { get; set; }
    }
}
