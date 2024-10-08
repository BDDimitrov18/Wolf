﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetPlotDTO
    {
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

            public string DisplayMemberPlot
            {
                 get
                 {
                    return $"{PlotNumber} {City}";
                 }
            }

        // Foreign key to Activity
    }
}
