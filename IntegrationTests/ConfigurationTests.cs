using System;
using System.Collections.Generic;
using System.Linq;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationAPI.DTO;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.Report;
using IntegrationTests.Integration;
using IntegrationTests.Setup;
using IronPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Xunit;

namespace IntegrationTests
{
    public class ConfigurationTests : BaseIntegrationTest
    {
        public ConfigurationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }


        private static ReportController SetupController(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<IReportService>());
        } 

        public static ReportGeneratorService _reportGeneratorService = new ReportGeneratorService();

        [Fact]
        public void Create_report()
        {
            
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            ReportDTO result = new ReportDTO(Period.Daily, new Guid());
            controller.Create(result);
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Update_report()
        {
            
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            ReportDTO resultDTO = new ReportDTO(Period.EveryTwoMonths, new Guid("6799e115-a7b0-4d37-be5e-ecbb1929b3a2"));
            Assert.NotNull(controller.Update(resultDTO));

        }
        
        [Fact]
        public void Read_report()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            ActionResult result = controller.GetAll();
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Get_information_for_report()
        {

        }
        
        [Fact]
        public void Generating_pdf()
        {

            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            if (controller != null)
            {
                var result = _reportGeneratorService.GeneratePdf(controller.GetById(new Guid("204932d0-7956-4199-9e0d-cf2903c9903b")));
            
                Assert.NotNull(result);
            }
        }  
        
    }
}
