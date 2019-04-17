namespace Domain.UseCases.Reports.Read
{
    using Domain.Dtos;
    using Domain.Shared;

    public class ReadReportsResponse
    {
        public PageModel<ReportDto> Reports { get; set; }
    }
}
