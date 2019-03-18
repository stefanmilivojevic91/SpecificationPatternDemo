using Domain.Entities;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Specifications
{
    public class ReportSpecification : ISpecification<Report>
    {
        public ReportSpecification()
        {
            Predicate = report => report.InstructedSpeed.HasValue 
                               && report.AverageSpeed.HasValue;
        }

        public Expression<Func<Report, bool>> Predicate { get; }
    }
}
