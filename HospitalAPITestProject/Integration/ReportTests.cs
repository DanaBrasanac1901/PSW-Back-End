using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Services;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAPITestProject.Integration
{
    public class ReportTests : BaseIntegrationTest
    {
        public ReportTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static ReportController SetupController(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<IDrugApplicationService>() 
                ,scope.ServiceProvider.GetRequiredService<ISymptomApplicationService>()
                ,scope.ServiceProvider.GetRequiredService<IReportApplicationService>());
        }

        private static ReportToCreateDTO SetUpReportToCreateDTO(IServiceScope scope)
        {
            return new ReportToCreateDTO(scope.ServiceProvider.GetRequiredService<IReportApplicationService>());
        }

        [Fact]
        public void Create_Report()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            var record = SetUpReportToCreateDTO(scope);
            var result = ((OkObjectResult)controller.CreateReport(record))?.Value as string;
            Assert.Equal("Passed", result);
        }
    }
}
