using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DTOS.CustomValidation
{
    public class NumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            // Check if the value is a string
            if (value is string stringValue)
            {
                // Regular expression to check if the string consists only of digits
                if (Regex.IsMatch(stringValue, @"^\d+$"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The field must be a string containing only digits.");
                }
            }

            return new ValidationResult("The field must be a string.");
        }
    }
}
