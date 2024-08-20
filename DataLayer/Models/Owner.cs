using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Owner
    {
        [Key]
        public int OwnerID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string? EGN { get; set; }

        public string? Address { get; set; }
        public string FullName { get; set; }

        public ICollection<DocumentOfOwnership_OwnerRelashionship> documentOfOwnership_OwnerRelashionships{ get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
