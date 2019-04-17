using Domain.Entities;
using System;
using System.Linq.Expressions;
using dtos = Domain.Dtos;

namespace Domain.Selectors.Reports
{
    public static class ReportsSelectors
    {
        public static Expression<Func<Report, dtos.ReportDto>> ReportSelector = report => new dtos.ReportDto
        {
            ReportId = report.ReportId,
            AverageSpeed = report.AverageSpeed,
            InstructedSpeed = report.InstructedSpeed,
            ReportTypeId = report.ReportTypeId
        };
    }
}
