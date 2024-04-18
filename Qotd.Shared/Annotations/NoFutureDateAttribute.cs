using System.ComponentModel.DataAnnotations;

namespace Qotd.Shared.Annotations;

internal class NoFutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateOnly dateToCheck && dateToCheck > DateOnly.FromDateTime(DateTime.Today))
        {
            return new ValidationResult("Datum ist in der Zukunft", [nameof(validationContext.MemberName)]);
        }

        return ValidationResult.Success;
    }
}
