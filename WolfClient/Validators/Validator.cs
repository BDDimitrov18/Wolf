using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WolfClient.Validators
{
    public static class Validator
    {
        public static IList<ValidationResult> Validate(object obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, context, results, validateAllProperties: true);

            // List for results with member names
            var memberNameResults = new List<ValidationResult>();

            // Manually validate each property to ensure member names are populated
            var propertyInfos = obj.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var propertyValue = propertyInfo.GetValue(obj);
                var validationAttributes = propertyInfo.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>();

                foreach (var attribute in validationAttributes)
                {
                    var validationContext = new ValidationContext(obj) { MemberName = propertyInfo.Name };
                    var result = attribute.GetValidationResult(propertyValue, validationContext);
                    if (result != ValidationResult.Success)
                    {
                        // Only add if it's not already in the results
                        if (!results.Any(r => r.ErrorMessage == result.ErrorMessage && r.MemberNames.Contains(propertyInfo.Name)))
                        {
                            memberNameResults.Add(new ValidationResult(result.ErrorMessage, new[] { propertyInfo.Name }));
                        }
                    }
                }
            }

            // Add results from TryValidateObject if they have member names
            foreach (var result in results)
            {
                if (result.MemberNames != null && result.MemberNames.Any())
                {
                    memberNameResults.Add(result);
                }
            }

            return memberNameResults.Distinct(new ValidationResultComparer()).ToList();
        }
    }
}
