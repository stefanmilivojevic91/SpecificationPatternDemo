using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Shared;
using Domain.Specifications.Reports;
using Domain.Selectors.Reports;
using System.Linq;

namespace Domain.UseCases.Reports.DeleteReport
{
    public class DeleteReportUseCase : IUseCase<int, DeleteReportResponse>
    {
        private readonly IReportRepository _reportsRepository;

        public DeleteReportUseCase(IReportRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        public async Task<DeleteReportResponse> Execute(int request)
        {
            var idSpecification = new IdSpecification(request);

            var reportQueryable = _reportsRepository.Get(idSpecification);

            var report = await _reportsRepository.SingleOrDefaultAsync(reportQueryable);

            if (report == null)
            {
                return new DeleteReportResponse
                {
                    Succedeed = false
                };
            }

            _reportsRepository.RemoveEntity(report);

            await _reportsRepository.SaveChangesAsync();

            return new DeleteReportResponse
            {
                Succedeed = true
            };
        }
    }
}
