using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CompositeDataDTO
    {
        public List<RequestWithClientsDTO> _fetchedLinkedClients { get; set; }
        public List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> linkedDocuments {get; set;}
    }
}
