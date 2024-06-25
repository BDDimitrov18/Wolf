﻿using DTOS.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace DTOS.DTO
{
    public class CreateEmployeeDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [OptionalPhone(ErrorMessage = "Ivalid Phone")]
        public string phone { get; set; }
        [Required]
        [OptionalEmailAddress(ErrorMessage = "Ivalid Email")]
        public string Email { get; set; }
    }
}
