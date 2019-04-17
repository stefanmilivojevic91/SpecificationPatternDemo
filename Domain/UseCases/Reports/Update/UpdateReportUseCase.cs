using Domain.Interfaces;
using Domain.Shared;
using Domain.Specifications.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Resources;
using System.Threading.Tasks;

namespace Domain.UseCases.Reports.Update
{
    public class UpdateReportUseCase : IUseCase<UpdateReportRequest, UpdateReportResponse>
    {
        private readonly IReportRepository _reportRepository;

        private readonly IValidationService _validationService;

        public UpdateReportUseCase(IReportRepository reportRepository,
                                   IValidationService validationService)
        {
            _reportRepository = reportRepository;
            _validationService = validationService;
        }

        public async Task<UpdateReportResponse> Execute(UpdateReportRequest request)
        {
            var validationErrors = _validationService.Validate(request.Model);

            if (validationErrors.Any())
            {
                return new UpdateReportResponse
                {
                    Data = new Either<Dtos.ReportDto, IEnumerable<KeyValuePair<string, string>>>(validationErrors)
                };
            }

            var idSpecification = new IdSpecification(request.ReportId);

            var reportQueryable = _reportRepository.Get(idSpecification);

            var report = await _reportRepository.SingleOrDefaultAsync(reportQueryable);

            if (report == null)
            {
                var message = string.Format(DomainMessages.ReportNull, request.ReportId);
                var reportNullError = new KeyValuePair<string, string>(nameof(request.ReportId), message);

                return new UpdateReportResponse
                {
                    Data = new Either<Dtos.ReportDto, IEnumerable<KeyValuePair<string, string>>>(new List<KeyValuePair<string, string>> { reportNullError })
                };
            }

            report.ReportTypeId = (int)request.Model.ReportTypeId;
            report.AverageSpeed = request.Model.AverageSpeed;
            report.InstructedSpeed = request.Model.InstructedSpeed;

            await _reportRepository.SaveChangesAsync();

            return new UpdateReportResponse
            {
                Data = new Either<Dtos.ReportDto, IEnumerable<KeyValuePair<string, string>>>(new Dtos.ReportDto
                {
                    ReportId = report.ReportId,
                    AverageSpeed = report.AverageSpeed,
                    InstructedSpeed = report.InstructedSpeed,
                    ReportTypeId = report.ReportTypeId
                })
            };
        }
    }
}
