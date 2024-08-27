using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPoint.Application.Tools.Validators
{
    public class ComparePasswordAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public ComparePasswordAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = value?.ToString();
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance)?.ToString();

            if (currentValue != comparisonValue)
            {
                return new ValidationResult(ErrorMessage ?? "The password confirmation does not match the password.");
            }

            return ValidationResult.Success;
        }
    }
}
