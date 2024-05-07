using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Business.Validators
{
    internal class CustomTimeValidator: ValidationAttribute
    {
        private const string RegexPattern = "^([01][0-9]|2[0-3]):[0-5][0-9]$";

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is string timeString)
            {
                if (!Regex.IsMatch(timeString, RegexPattern))
                {
                    return new ValidationResult($"{context.DisplayName} is an invalid time. Please use HH:MM format.");
                }
            }

            return ValidationResult.Success;
        }

    }
}
