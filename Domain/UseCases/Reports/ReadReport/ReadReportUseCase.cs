using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Shared;
using Domain.Specifications.Reports;
using Domain.Selectors.Reports;

namespace Domain.UseCases.Reports.ReadReport
{
    public class ReadReportUseCase : IUseCase<int, ReadReportResponse>
    {
        private readonly IReportRepository _reportRepository;

        public ReadReportUseCase(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ReadReportResponse> Execute(int request)
        {
            var specification = new IdSpecification(request);

            var reportQuery = _reportRepository.Get(specification);

            var projection = reportQuery.Select(ReportsSelectors.ReportSelector);

            var reportDto = await _reportRepository.SingleOrDefaultAsync(projection);

            if (reportDto == null)
            {
                return new ReadReportResponse
                {
                    Report = new Either<Dtos.ReportDto, UseCaseResponse>(UseCaseResponse.Null())
                };
            }

            return new ReadReportResponse
            {
                Report = new Either<Dtos.ReportDto, UseCaseResponse>(reportDto)
            };
        }
    }
}
