using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskPoint.Application.Tools.Validators
{
    public class NoSpecialCharactersAttribute : ValidationAttribute
    {
        private const string Pattern = "^[a-zA-Z0-9 ]*$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var name = value as string;

            if (!Regex.IsMatch(name, Pattern))
            {
                return new ValidationResult("The name field cannot contain special characters.");
            }

            return ValidationResult.Success;
        }
    }
}
