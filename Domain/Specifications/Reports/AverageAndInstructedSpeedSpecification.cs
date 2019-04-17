namespace Domain.Specifications.Reports
{
    using System;
    using System.Linq.Expressions;
    using Entities;
    using Shared;

    public class AverageAndInstructedSpeedSpecification : ISpecification<Report>
    {
        public AverageAndInstructedSpeedSpecification()
        {
            Predicate = report => report.AverageSpeed.HasValue
                               && report.InstructedSpeed.HasValue;
        }

        public Expression<Func<Report, bool>> Predicate { get; }
    }
}
