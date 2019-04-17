using Domain.Dtos;
using Domain.Shared;

namespace Domain.UseCases.Reports.ReadReport
{
    public class ReadReportResponse
    {
        public Either<ReportDto,UseCaseResponse>  Report { get; set; }
    }
}
