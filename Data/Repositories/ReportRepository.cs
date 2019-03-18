using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ReportRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<Report> GetList(ISpecification<Report> specification)
        {
            return _databaseContext.Set<Report>()
                                   .Where(specification.Predicate);
        }

        public async Task<IEnumerable<ReportDto>> Execute(IQueryable<ReportDto> query)
        {
            return await query.ToListAsync();
        }
    }
}
