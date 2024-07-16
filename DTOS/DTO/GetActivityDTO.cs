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
        public GetRequestDTO? Request { get; set; }

        public int ActivityTypeID { get; set; }
        public GetActivityTypeDTO? ActivityType { get; set; }

        public int? ParentActivityId { get; set; }
        public GetActivityDTO? ParentActivity { get; set; }

        public DateTime ExpectedDuration { get; set; }
        public DateTime StartDate { get; set; }
        public float employeePayment { get; set; }
        public int ExecutantId { get; set; }
        public GetEmployeeDTO mainExecutant { get; set; }

        public ICollection<GetTaskDTO>? Tasks { get; set; }

        public ICollection<GetPlotDTO>? Plots { get; set; }

        private string _activityTypeName = "";
        public string ActivityTypeName
        {
            get
            {
                if (_activityTypeName == "")
                {
                    return $"{ActivityType?.ActivityTypeName ?? "Unknown"} {{ActivityId: {ActivityId}}}";
                }
                else {
                    return _activityTypeName;
                }
            }
            set {
                _activityTypeName = value;
            }
        }
    }
}
