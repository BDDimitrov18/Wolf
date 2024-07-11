using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreatePowerOfAttorneyDocumentDTO
    {
        public string number { get; set; }

        public DateTime dateOfIssuing { get; set; }

        public string Issuer { get; set; }
    }
}
