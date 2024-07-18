using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Files
    {
        [Key]
        public int FileId { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public DateTime UploadedAt { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
