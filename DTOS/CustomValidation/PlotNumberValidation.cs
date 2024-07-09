using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DTOS.CustomValidation
{
    public class PlotNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var stringValue = value.ToString();

            // Define the regex pattern for the specified format
            string pattern = @"^\d{5}\.\d{1,4}\.\d{1,4}(\.\d{1,2})?(\.\d{1,4})?$";

            // Check if the string matches the pattern
            if (Regex.IsMatch(stringValue, pattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The field must be in the format 6 digits . 1-4 digits . 1-4 digits . optional 1-2 digits . optional 1-4 digits.");
        }
    }
}
