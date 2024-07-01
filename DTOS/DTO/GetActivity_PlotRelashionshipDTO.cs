using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetActivity_PlotRelashionshipDTO
    {
        public int ActivityId { get; set; }
        public GetActivityDTO Activity { get; set; }

        public int PlotId { get; set; }
        public GetPlotDTO Plot { get; set; }
    }
}
