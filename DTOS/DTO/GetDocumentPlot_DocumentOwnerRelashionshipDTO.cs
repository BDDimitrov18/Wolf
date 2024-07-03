using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetDocumentPlot_DocumentOwnerRelashionshipDTO
    {
        public int DocumentPlotId { get; set; }
        public GetPlot_DocumentOfOwnershipRelashionshipDTO DocumentPlot { get; set; }

        public int DocumentOwnerID { get; set; }

        public GetDocumentOfOwnership_OwnerRelashionshipDTO DocumentOwner { get; set; }

        public float IdealParts { get; set; }

        public string WayOfAcquiring { get; set; }
    }
}
