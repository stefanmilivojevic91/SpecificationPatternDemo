using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Shared;
using Domain.UseCases.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ReadReportsTests
    {
        private readonly ReadReportsUseCase _readReportsUseCase;

        private readonly Mock<IReportRepository> _reportRepositoryMock;

        public ReadReportsTests()
        {
            _reportRepositoryMock = new Mock<IReportRepository>();

            _readReportsUseCase = new ReadReportsUseCase(_reportRepositoryMock.Object);
        }

        [TestMethod]
        public async Task ReadReportsTests_Success()
        {
            var mockedReports = new List<Report>
            {
                new Report
                {
                    ReportId = 1,
                    AverageSpeed = 100,
                    InstructedSpeed = 100,
                    ReportTypeId = 1
                },
                new Report
                {
                    ReportId = 2,
                    AverageSpeed = 100,
                    InstructedSpeed = 100,
                    ReportTypeId = 1
                }
            };

            _reportRepositoryMock.Setup(item => item.GetList(It.IsAny<ISpecification<Report>>()))
                .Returns((ISpecification<Report> specification) => mockedReports.AsQueryable().Where(specification.Predicate));

            _reportRepositoryMock.Setup(item => item.Execute(It.IsAny<IQueryable<ReportDto>>()))
                .Returns((IQueryable<ReportDto> reports) => Task.FromResult(reports.AsEnumerable()));

            var request = new ReadReportsRequest
            {
                Limit = 100,
                Offset = 0
            };

            var response = await _readReportsUseCase.Execute(request);

            Assert.IsNotNull(response);
        }
    }
}
