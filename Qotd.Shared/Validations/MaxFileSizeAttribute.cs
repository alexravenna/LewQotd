using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace Qotd.Shared.Validations;

[AttributeUsage(AttributeTargets.Property)]
public class MaxFileSizeAttribute(long maxFileSize) : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is IBrowserFile file)
        {
            if (file.Size > maxFileSize)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}