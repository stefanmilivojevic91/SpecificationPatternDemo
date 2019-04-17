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

        public Task<int> CountAsync(IQueryable<Report> query)
        {
            return query.CountAsync();
        }

        public Task<List<T>> ToListAsync<T>(IQueryable<T> query)
        {
            return query.ToListAsync();
        }

        public IQueryable<Report> Get(ISpecification<Report> specification)
        {
            return _databaseContext.Set<Report>()
                                   .Where(specification.Predicate);
        }

        public void AddEntity(Report report)
        {
            _databaseContext.Reports.Add(report);
        }

        public Task SaveChangesAsync()
        {
            return _databaseContext.SaveChangesAsync();
        }

        public Task<T> SingleOrDefaultAsync<T>(IQueryable<T> query)
        {
            return query.SingleOrDefaultAsync();
        }

        public void RemoveEntity(Report report)
        {
            _databaseContext.Reports.Remove(report);
        }
    }
}
