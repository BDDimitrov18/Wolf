using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DTOS.CustomValidation
{
    public class EgnAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var stringValue = value.ToString();

            // Check if the string is numeric and has between 9 and 13 digits
            if (Regex.IsMatch(stringValue, @"^\d{9,13}$"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The field must be a string containing between 9 and 13 digits.");
        }
    }
}
