using System.Threading.Tasks;
using Domain.Shared;
using Domain.UseCases.Reports.Read;
using Domain.UseCases.Reports.Create;
using Domain.UseCases.Reports.ReadReport;
using Microsoft.AspNetCore.Mvc;
using Domain.UseCases.Reports.DeleteReport;
using System;
using Domain.Models;
using Domain.UseCases.Reports.Update;

namespace SpecificationPatternDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IUseCase<ReadReportsRequest, ReadReportsResponse> _readReportsUseCase;
        private readonly IUseCase<int, ReadReportResponse> _readReportUseCase;
        private readonly IUseCase<CreateReportRequest, CreateReportResponse> _createReportUseCase;
        private readonly IUseCase<UpdateReportRequest, UpdateReportResponse> _updateReportUseCase;
        private readonly IUseCase<int, DeleteReportResponse> _deleteReportUseCase;

        public ReportsController(IUseCase<ReadReportsRequest, ReadReportsResponse> readReportsUseCase,
                                 IUseCase<int, ReadReportResponse> readReportUseCase,
                                 IUseCase<CreateReportRequest, CreateReportResponse> createReportUseCase,
                                 IUseCase<UpdateReportRequest, UpdateReportResponse> updateReportUseCase,
                                 IUseCase<int, DeleteReportResponse> deleteReportUseCase)
        {
            _readReportsUseCase = readReportsUseCase;
            _readReportUseCase = readReportUseCase;
            _createReportUseCase = createReportUseCase;
            _updateReportUseCase = updateReportUseCase;
            _deleteReportUseCase = deleteReportUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int limit = 10, int offset = 0)
        {
            var response = await _readReportsUseCase.Execute(new ReadReportsRequest
            {
                Limit = limit,
                Offset = offset
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _readReportUseCase.Execute(id);

            return response.Report.Match<IActionResult>(item => Ok(item), item => NotFound(item));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReportModel model)
        {
            var useCaseRequest = new CreateReportRequest
            {
                Model = model
            };

            var response = await _createReportUseCase.Execute(useCaseRequest);

            return response.Data.Match<IActionResult>(item => Ok(item), item => BadRequest(item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ReportModel model)
        {
            var request = new UpdateReportRequest
            {
                ReportId = id,
                Model = model
            };

            var response = await _updateReportUseCase.Execute(request);

            return response.Data.Match<IActionResult>(item => Ok(item), item => BadRequest(item));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _deleteReportUseCase.Execute(id);

            return Ok(response);
        }
    }
}
