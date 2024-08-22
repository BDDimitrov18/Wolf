using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetOwnerDTO
    {
        public int OwnerID { get; set; }

        public string? EGN { get; set; }

        public string? Address { get; set; }

        public string FullName { get; set; }

    }
}
