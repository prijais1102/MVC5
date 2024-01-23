
using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    internal class BirthYearValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? DateOfBirth = (DateTime?)value;
                if (DateOfBirth.HasValue)
                {
                    if (Convert.ToDateTime(DateOfBirth).Year >=2002 && Convert.ToDateTime(DateOfBirth).Year <=2005)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult(ErrorMessage ?? "Date of birth should be in this range:2002-2005");
        }
    }
}