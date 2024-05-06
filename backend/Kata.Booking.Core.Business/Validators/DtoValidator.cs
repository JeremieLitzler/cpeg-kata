using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Business.Validators
{
    internal static class DtoValidator
    {
        internal static void Validate(Object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(entity, validationContext, validationResults, true);

            if (validationResults.Any())
            {
                var messages = validationResults.Select(error => error.ErrorMessage).ToArray();
                throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, messages);
            }
        }
    }
}
