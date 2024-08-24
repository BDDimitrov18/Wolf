using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.TemplateClasses
{
    public class TaskTypeSelection
    {
        public int TaskTypeId { get; set; }
        public string TaskTypeName { get; set; }
        public bool IsSelected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TaskTypeSelection other)
            {
                return this.TaskTypeId == other.TaskTypeId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return TaskTypeId.GetHashCode();
        }
    }
}
