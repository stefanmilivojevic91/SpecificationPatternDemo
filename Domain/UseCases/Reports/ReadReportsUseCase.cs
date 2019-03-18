using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using Domain.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.UseCases.Reports
{
    public class ReadReportsUseCase : IUseCase<ReadReportsRequest, ReadReportsResponse>
    {
        private readonly IReportRepository _reportRepository;

        public ReadReportsUseCase(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ReadReportsResponse> Execute(ReadReportsRequest request)
        {
            var specificatication = new ReportSpecification();

            var reportsQuery = _reportRepository.GetList(specificatication);

            reportsQuery = reportsQuery.Skip(request.Offset)
                                       .Take(request.Limit);

            Expression<Func<Report, Dtos.ReportDto>> selector = report => new Dtos.ReportDto
            {
                ReportId = report.ReportId,
                AverageSpeed = report.AverageSpeed,
                InstructedSpeed = report.InstructedSpeed,
                ReportTypeId = report.ReportTypeId
            };

            var projectedDataQuery = reportsQuery.Select(selector);

            var reports = await _reportRepository.Execute(projectedDataQuery);

            return new ReadReportsResponse
            {
                Reports = reports
            };
        }
    }
}
