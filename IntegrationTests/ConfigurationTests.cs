using System;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Report;
using IntegrationTests.Integration;
using IntegrationTests.Setup;
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

        [Fact]
        public void Test1()
        {

        }
        
        [Fact]
        public void Generating_pdf()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            // da imamo CRU u kontroleru i neki thread mozda koji proverava konstantno je l dns dan za kreiranje 
            //reporta; ili jos jednu fju Generate koja se poziva prilikom pokretanja mzd appa? i proverava svaki dan
            //kako se skladisti ovaj Pdf treba skontati, dto ili
          //  var result = ((OkObjectResult)controller.Generate() as ReportPdf;

            //Assert.NotNull(result);
        }

        
    }
}
