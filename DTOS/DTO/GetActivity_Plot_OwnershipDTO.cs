using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetActivity_Plot_OwnershipDTO
    {
        public List<GetActivity_PlotRelashionshipDTO> activity_PlotRelashionshipDTOs { get; set; }

        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> getDocumentPlot_DocumentOwnerRelashionshipDTOs { get; set; }
    }

}
