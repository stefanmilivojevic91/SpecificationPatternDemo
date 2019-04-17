using Domain.Dtos;
using Domain.Shared;
using System.Collections.Generic;

namespace Domain.UseCases.Reports.Create
{
    public class CreateReportResponse
    {
        public Either<ReportDto, IEnumerable<KeyValuePair<string, string>>> Data { get; set; }
    }
}
