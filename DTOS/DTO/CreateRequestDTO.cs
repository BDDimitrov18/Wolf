using DTOS.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateRequestDTO
    {
        public float Price { get; set; }

        public string PaymentStatus { get ; set; }

        public float Advance { get; set; }

        public string? Comments { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string RequestName { get; set; }

        public string? Path { get; set; }

        public int? RequestCreatorId { get; set; }

    }
}
