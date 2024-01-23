using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    public class JoiningYearValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? DateOfJoining = (DateTime?)value;
                if (DateOfJoining.HasValue)
                {
                    if (DateOfJoining <= DateTime.Now)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult(ErrorMessage ?? "Date of joining should be less than today's date.");
        }
    }
}
