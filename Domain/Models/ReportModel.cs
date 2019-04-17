using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ReportModel
    {
        [Required]
        public ReportType? ReportTypeId { get; set; }

        [Required]
        public double? AverageSpeed { get; set; }

        [Required]
        public double? InstructedSpeed { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Mrk { get; set; }
    }
}
