using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class GetActivityDTO
    {
        public int ActivityId { get; set; }

        public int RequestId { get; set; }
        public GetRequestDTO Request { get; set; }

        public int ActivityTypeID { get; set; }
        public GetActivityTypeDTO ActivityType { get; set; }

        public DateTime ExpectedDuration { get; set; }

        public ICollection<GetTaskDTO> Tasks { get; set; }

        public string ActivityTypeName
        {
            get
            {
                return $"{ActivityType?.ActivityTypeName ?? "Unknown"} {{ActivityId: {ActivityId}}}";
            }
        }
    }
}
