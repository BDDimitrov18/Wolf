using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;//OptionalEmailAddressAttribute

namespace DTOS.CustomValidation
{
    public class OptionalEmailAddressAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field is not a valid email address.";

        public OptionalEmailAddressAttribute() : base(DefaultErrorMessage) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var email = value.ToString();
            var emailAddressAttribute = new EmailAddressAttribute();

            // Initial email validation using EmailAddressAttribute
            if (!emailAddressAttribute.IsValid(email))
            {
                return new ValidationResult("Invalid Email Address");
            }

            // Additional regex validation for more strict email format
            if (!IsValidEmail(email))
            {
                return new ValidationResult("Invalid Email Address");
            }

            return ValidationResult.Success;
        }

        private bool IsValidEmail(string email)
        {
            // Regex for email validation, ensuring a dot after the "@" symbol
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }
    }


}
