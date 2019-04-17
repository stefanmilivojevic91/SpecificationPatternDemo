using Domain.Interfaces;
using Domain.Shared;
using Domain.Specifications.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.UseCases.Reports.Create
{
    public class CreateReportUseCase : IUseCase<CreateReportRequest, CreateReportResponse>
    {
        private readonly IReportRepository _reportRepository;

        private readonly IValidationService _validationService;

        public CreateReportUseCase(IReportRepository reportRepository,
                                   IValidationService validationService)
        {
            _reportRepository = reportRepository;
            _validationService = validationService;
        }

        public async Task<CreateReportResponse> Execute(CreateReportRequest request)
        {
            var validationErrors = _validationService.Validate(request);

            if (validationErrors.Any())
            {
                return new CreateReportResponse
                {
                    Data = new Either<Dtos.ReportDto, IEnumerable<KeyValuePair<string, string>>>(validationErrors)
                };
            }

            var report = new Entities.Report();

            _reportRepository.AddEntity(report);

            report.ReportTypeId = (int)request.Model.ReportTypeId;
            report.AverageSpeed = request.Model.AverageSpeed;
            report.InstructedSpeed = request.Model.InstructedSpeed;

            await _reportRepository.SaveChangesAsync();

            return new CreateReportResponse
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
