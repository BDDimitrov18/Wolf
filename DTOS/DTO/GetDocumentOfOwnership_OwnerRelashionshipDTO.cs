using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetDocumentOfOwnership_OwnerRelashionshipDTO
    {
        public int DocumentOwnerID { get; set; }
        public int DocumentID { get; set; }
        public GetDocumentOfOwnershipDTO Document { get; set; }
        public int OwnerID { get; set; }
        public GetOwnerDTO Owner { get; set; }
    }
}
