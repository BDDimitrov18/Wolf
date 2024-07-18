using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Plot
    {
        [Key]
        public int PlotId { get; set; }

        public string PlotNumber { get; set; }

        public string? RegulatedPlotNumber { get; set; }

        public string? neighborhood { get; set; }

        public string? City { get; set; }

        public string? Municipality { get; set; }

        public string? Street { get; set; }

        public int? StreetNumber { get; set; }

        public string designation { get; set; }

        public string? locality { get; set; }

        public ICollection<Plot_DocumentOfOwnershipRelashionship> PlotDocuments { get; set; }


        // Foreign key to Activity
        public ICollection<Activity_PlotRelashionship> ActivityPlots { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
