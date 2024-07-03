using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetPlot_DocumentOfOwnershipRelashionshipDTO
    {
        public int DocumentPlotId { get; set; }

        public int PlotId { get; set; }

        public GetPlotDTO Plot { get; set; }

        public int DocumentOfOwnershipId { get; set; }
        public GetDocumentOfOwnershipDTO documentOfOwnership { get; set; }
    }
}
