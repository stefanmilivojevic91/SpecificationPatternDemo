using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UseCases.Reports
{
    public class ReadReportsResponse
    {
        public IEnumerable<ReportDto> Reports { get; set; }
    }
}
