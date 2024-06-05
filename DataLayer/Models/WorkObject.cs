using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class WorkObject
    {
        [Key]
        public int WorkObjectId { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public ICollection<WorkObject_PlotRelashionship> WorkObject_PlotRelationships { get; set; }

        public ICollection<Request_WorkObjectRelashionship> Request_WorkObjectRelationships { get; set; }

        public ICollection<Employee_WorkObjectRelashionship> Employee_WorkObjectRelationships { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
