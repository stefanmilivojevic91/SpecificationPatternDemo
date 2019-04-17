using Domain.Entities;
using Domain.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReportRepository
    {
        IQueryable<Report> Get(ISpecification<Report> specification);

        Task<List<T>> ToListAsync<T>(IQueryable<T> query);

        Task<T> SingleOrDefaultAsync<T>(IQueryable<T> query);

        Task<int> CountAsync(IQueryable<Report> query);

        void AddEntity(Report report);

        void RemoveEntity(Report report);

        Task SaveChangesAsync();
    }
}
