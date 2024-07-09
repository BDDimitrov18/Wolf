using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetDocumentOfOwnershipDTO
    {
        public int DocumentId { get; set; }
        public string TypeOfDocument { get; set; }
        public string NumberOfDocument { get; set; }
        public string Issuer { get; set; }
        public int TOM { get; set; }
        public string register { get; set; }
        public string DocCase { get; set; }
        public string TypeOfOwnership { get; set; }

        public DateTime DateOfIssuing { get; set; }
        public DateTime DateOfRegistering { get; set; }
    }
}
