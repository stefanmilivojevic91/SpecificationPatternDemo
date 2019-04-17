namespace Domain.UseCases.Reports.Read
{
    using Domain.Entities;
    using Domain.Interfaces;
    using Domain.Selectors.Reports;
    using Domain.Shared;
    using Domain.Specifications.Reports;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class ReadReportsUseCase : IUseCase<ReadReportsRequest, ReadReportsResponse>
    {
        private readonly IReportRepository _reportRepository;

        public ReadReportsUseCase(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ReadReportsResponse> Execute(ReadReportsRequest request)
        {
            var averageInstructedSpeedSpecification = new AverageAndInstructedSpeedSpecification();

            var reportsQuery = _reportRepository.Get(averageInstructedSpeedSpecification);

            reportsQuery = reportsQuery.Skip(request.Offset)
                                       .Take(request.Limit);

            var totalCount = await _reportRepository.CountAsync(reportsQuery);

            var projectedDataQuery = reportsQuery.Select(ReportsSelectors.ReportSelector);

            var reports = await _reportRepository.ToListAsync(projectedDataQuery);

            return new ReadReportsResponse
            {
                Reports = new PageModel<Dtos.ReportDto>
                {
                    Items = reports,
                    Total = totalCount
                }
            };
        }
    }
}
