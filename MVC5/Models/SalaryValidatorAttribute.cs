
using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    internal class SalaryValidatorAttribute : ValidationAttribute
    {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    int? Salary = (int?)value;
                    if (Salary.HasValue)
                    {
                        if (Salary >= 12000 && Salary<=60000)
                        {
                            return ValidationResult.Success;
                        }
                    }
                }
                return new ValidationResult(ErrorMessage ?? "Salary should be within this range:12k-60k");
            }
        }
    }