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

        public int PlotNumber { get; set; }

        public int? RegulatedPlotNumber { get; set; }

        public string? neighborhood { get; set; }

        public string? City { get; set; }

        public string? Municipality { get; set; }

        public string? Street { get; set; }

        public int? StreetNumber { get; set; }

        public string designation { get; set; }

        public string? locality { get; set; }

        public ICollection<WorkObject_PlotRelashionship> WorkObject_PlotRelationships { get; set; }
    }
}
