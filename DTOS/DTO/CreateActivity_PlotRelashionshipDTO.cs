using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateActivity_PlotRelashionshipDTO
    {
        public GetActivityDTO Activity { get; set; }

        public GetPlotDTO Plot { get; set; }
    }
}
