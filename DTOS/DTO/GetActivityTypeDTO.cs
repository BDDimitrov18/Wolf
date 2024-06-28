using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetActivityTypeDTO
    {
        public int ActivityTypeID { get; set; }

        public string ActivityTypeName { get; set; }

        public ICollection<GetTaskTypeDTO> TaskTypes { get; set; }


    }
}
