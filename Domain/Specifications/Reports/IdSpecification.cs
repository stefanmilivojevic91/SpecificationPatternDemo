using System;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Shared;

namespace Domain.Specifications.Reports
{
    public class IdSpecification : ISpecification<Report>
    {
        public IdSpecification(int? reportId)
        {
            Predicate = report => report.ReportId == reportId;
        }

        public Expression<Func<Report, bool>> Predicate { get; }
    }
}
