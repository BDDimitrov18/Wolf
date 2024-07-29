using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DTOS.CustomValidation
{
    public class FloatAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field must be a valid float.";

        public FloatAttribute() : base(DefaultErrorMessage) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var input = value.ToString();

            if (IsValidFloat(input))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        private bool IsValidFloat(string input)
        {
            // Regex for validating float: allows numbers and a single dot
            var regex = new Regex(@"^[0-9]*\,?[0-9]+$");
            return regex.IsMatch(input);
        }
    }
}
