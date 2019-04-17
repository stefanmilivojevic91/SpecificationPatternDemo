using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UseCases.Reports.Read
{
    public class ReadReportsRequest
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
