using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.CustomValidation
{
    public class OptionalPhoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var phoneAttribute = new PhoneAttribute();
            if (!phoneAttribute.IsValid(value))
            {
                return new ValidationResult("Invalid Phone Number");
            }

            return ValidationResult.Success;
        }
    }
}
