using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TaskPoint.Application.Tools.Validators;

public class PasswordComplexityAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value?.ToString();

        if (string.IsNullOrEmpty(password))
        {
            return new ValidationResult("Password is required.");
        }
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$");

        if (!regex.IsMatch(password))
        {
            return new ValidationResult(ErrorMessage ?? "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
        }

        return ValidationResult.Success;
    }
}
