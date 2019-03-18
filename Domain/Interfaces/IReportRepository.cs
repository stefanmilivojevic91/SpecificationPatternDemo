using Domain.Dtos;
using Domain.Entities;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReportRepository
    {
        IQueryable<Report> GetList(ISpecification<Report> specification);

        Task<IEnumerable<ReportDto>> Execute(IQueryable<ReportDto> query);
    }
}
