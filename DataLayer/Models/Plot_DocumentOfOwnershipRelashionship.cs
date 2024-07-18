using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Plot_DocumentOfOwnershipRelashionship
    {
        [Key]
        public int DocumentPlotId { get; set; }

        public int PlotId { get; set; }

        public Plot Plot { get; set; }

        public int  DocumentOfOwnershipId{ get; set; }
        public DocumentOfOwnership  documentOfOwnership { get; set; }

        public ICollection<DocumentPlot_DocumentOwnerRelashionship> documentPlot_DocumentOwnerRelashionships { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
