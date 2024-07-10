using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateFileDTO
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
