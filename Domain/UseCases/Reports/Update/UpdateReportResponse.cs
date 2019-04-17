using Domain.Dtos;
using Domain.Shared;
using System.Collections.Generic;

namespace Domain.UseCases.Reports.Update
{
    public class UpdateReportResponse
    {
        public Either<ReportDto, IEnumerable<KeyValuePair<string, string>>> Data { get; set; }
    }
}
