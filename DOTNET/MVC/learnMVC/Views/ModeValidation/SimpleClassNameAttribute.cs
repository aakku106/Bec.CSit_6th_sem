using System.ComponentModel.DataAnnotations;

public class SimpleClassNameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var className = value as string;
        if (string.IsNullOrEmpty(className)) { return new ValidationResult("ClassNameIsRequired "); }
        if (!char.IsDigit(className[0])) { return new ValidationResult("ClassNameMustStartWith a name"); }
        
        return ValidationResult.Success;
    }
}