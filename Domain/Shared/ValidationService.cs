using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain.Shared
{
    public class ValidationService : IValidationService
    {
        public IEnumerable<KeyValuePair<string, string>> Validate<T>(T model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);

            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, context, validationResults);

            if (!isValid)
            {
                return validationResults.Select(result =>
                new KeyValuePair<string, string>(result.MemberNames.SingleOrDefault(), result.ErrorMessage));
            }

            return Enumerable.Empty<KeyValuePair<string, string>>();
        }
    }
}
