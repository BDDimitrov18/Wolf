using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.ViewModels
{
    public class PlotViewModel : GetPlotDTO
    {
        public string ActivityName { get; set; }
    }
}
