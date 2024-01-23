
using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    internal class DepartmentValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string? Department = (string?)value;
                    if (Department.Equals("IT") || Department.Equals("ACCOUNTS") || Department.Equals("HR"))
                    {
                        return ValidationResult.Success;
                    }
                
            }
            return new ValidationResult(ErrorMessage ?? "Department can only be-IT,ACCOUNTS,HR");
        }
    }
}