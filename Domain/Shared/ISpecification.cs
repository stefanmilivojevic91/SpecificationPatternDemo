using System;
using System.Linq.Expressions;

namespace Domain.Shared
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
    }
}
