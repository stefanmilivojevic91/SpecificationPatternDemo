using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class ReportDto
    {
        public int ReportId { get; set; }
        public double? InstructedSpeed { get; set; }
        public double? AverageSpeed { get; set; }
        public int? ReportTypeId { get; set; }
    }
}
