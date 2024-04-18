using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qotd.Shared.Validations;

public class NoFutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateOnly dateToCheck)
        {
            if (dateToCheck > DateOnly.FromDateTime(DateTime.Today))
            {
                return new ValidationResult("Datum ist in der Zukunft", [nameof(validationContext.MemberName)]);
            }
        }

        return ValidationResult.Success;
    }
}