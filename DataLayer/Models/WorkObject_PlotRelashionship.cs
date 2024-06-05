using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class WorkObject_PlotRelashionship
    {
        public int WorkObjectId { get; set; }
        public WorkObject WorkObject { get; set; }

        public int PlotId { get; set; }
        public Plot Plot { get; set; }
    }
}
