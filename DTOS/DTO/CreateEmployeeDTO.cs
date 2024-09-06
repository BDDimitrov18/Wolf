using DTOS.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace DTOS.DTO
{
    public class CreateEmployeeDTO
    {
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle Name Required")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Middle Name Required")]
        public string LastName { get; set; }

        [Required]
        [OptionalPhone(ErrorMessage = "Ivalid Phone")]
        public string phone { get; set; }
        [Required]
        [OptionalEmailAddress(ErrorMessage = "Ivalid Email")]
        public string Email { get; set; }

        public bool Outsider { get; set; }
    }
}
