using Domain.Models;

namespace Domain.UseCases.Reports.Update
{
    public class UpdateReportRequest
    {
        public int ReportId { get; set; }
        public ReportModel Model { get; set; }
    }
}
