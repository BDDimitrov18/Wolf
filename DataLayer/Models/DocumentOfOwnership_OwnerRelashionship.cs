using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class DocumentOfOwnership_OwnerRelashionship
    {
        [Key]
        public int DocumentOwnerID { get; set; }
        public int DocumentID { get; set; }
        public DocumentOfOwnership Document { get; set; }
        public int OwnerID { get; set; }
        public Owner Owner { get; set; }

        public ICollection<DocumentPlot_DocumentOwnerRelashionship> documentPlot_DocumentOwnerRelashionships { get; set; }
    }
}
