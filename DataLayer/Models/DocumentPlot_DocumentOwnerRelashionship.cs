using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class DocumentPlot_DocumentOwnerRelashionship
    {
        [Key]
        public int Id { get; set; }
        public int DocumentPlotId { get; set; }
        public Plot_DocumentOfOwnershipRelashionship DocumentPlot { get; set; }

        public int DocumentOwnerID { get; set; }

        public DocumentOfOwnership_OwnerRelashionship DocumentOwner { get; set; }

        public float IdealParts { get; set; }

        public string WayOfAcquiring { get; set; }

        public bool isDrob { get; set; }

        public int PowerOfAttorneyId { get; set; }
        public PowerOfAttorneyDocument  powerOfAttorneyDocument { get; set; }
    }
}
