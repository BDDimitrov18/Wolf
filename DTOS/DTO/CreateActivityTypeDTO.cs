using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateActivityTypeDTO
    {
        [Key]
        public int ActivityTypeID { get; set; }

        public string ActivityTypeName { get; set; }

    }
}
