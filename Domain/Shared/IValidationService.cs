using System.Collections.Generic;

namespace Domain.Shared
{
    public interface IValidationService
    {
        IEnumerable<KeyValuePair<string, string>> Validate<T>(T model);
    }
}
