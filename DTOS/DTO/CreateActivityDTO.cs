using DTOS.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateActivityDTO
    {
        public int RequestId { get; set; }

        public int ActivityTypeID { get; set; }

        public int? ParentActivityId { get; set; }

        public DateTime ExpectedDuration { get; set; }
        public DateTime StartDate { get; set; }
        [Float(ErrorMessage = "Invalid float value")]
        public float employeePayment { get; set; }
        public int ExecutantId { get; set; }

    }
}
