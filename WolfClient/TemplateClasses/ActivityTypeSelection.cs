using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.TemplateClasses
{
    public class ActivityTypeSelection
    {
        public int ActivityTypeID { get; set; }
        public string ActivityTypeName { get; set; }
        public bool IsSelected { get; set; }
        public List<TaskTypeSelection> TaskTypeSelections { get; set; }
    }

}
