using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetFileDTO
    {
        public int FileId { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
