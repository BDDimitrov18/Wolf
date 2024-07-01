using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Activity_PlotRelashionship
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int PlotId { get; set; }
        public Plot Plot { get; set; }
    }
}
