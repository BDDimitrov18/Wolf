using DTOS.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.DTO
{
    public class CreateClientDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        [OptionalPhone(ErrorMessage ="Invalid Phone Number")]
        public string? Phone { get; set; }

        
        [OptionalEmailAddress(ErrorMessage = "Invalid Email Address")]
        
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ClientLegalType { get; set; }
    }
}
