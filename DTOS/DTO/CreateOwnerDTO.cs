using DTOS.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateOwnerDTO
    {

        [Required(ErrorMessage = "Egn is required")]
        [Egn(ErrorMessage = "Egn is wrong")]
        public string? EGN { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
