namespace Domain.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        public double? InstructedSpeed { get; set; }
        public double? AverageSpeed { get; set; }
        public int? ReportTypeId { get; set; }
    }
}
