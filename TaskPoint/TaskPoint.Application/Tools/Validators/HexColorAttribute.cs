using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskPoint.Application.Tools.Validators
{
    public class HexColorAttribute : ValidationAttribute
    {
        private const string HexPattern = "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var color = value as string;

            if (string.IsNullOrEmpty(color))
            {
                return ValidationResult.Success;
            }

            if (Regex.IsMatch(color, HexPattern))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The color value must be a valid hexadecimal code.");
            }
        }
    }
}
