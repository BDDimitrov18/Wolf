using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateDocumentPlot_DocumentOwnerRelashionshipDTO
    {
        public int DocumentPlotId { get; set; }

        public int DocumentOwnerID { get; set; }

        public float IdealParts { get; set; }

        public string WayOfAcquiring { get; set; }
        public bool isDrob { get; set; }

        public int PowerOfAttorneyId { get; set; }
    }
}
