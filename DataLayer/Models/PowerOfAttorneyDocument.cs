using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PowerOfAttorneyDocument
    {
        [Key]
        public int PowerOfAttorneyId { get; set; }
        public string number { get; set; }

        public DateTime dateOfIssuing { get; set; }



        public string Issuer { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
