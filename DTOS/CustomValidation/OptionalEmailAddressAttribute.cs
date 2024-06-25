using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.CustomValidation
{
    public class OptionalEmailAddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var emailAddressAttribute = new EmailAddressAttribute();
            if (!emailAddressAttribute.IsValid(value))
            {
                return new ValidationResult("Invalid Email Address");
            }

            return ValidationResult.Success;
        }
    }
}
