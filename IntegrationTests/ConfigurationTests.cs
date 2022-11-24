using System;
using System.Net;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Report;
using IntegrationTests.Integration;
using IntegrationTests.Setup;
using IronPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Nest;
using Xunit;

namespace IntegrationTests
{
    public class ConfigurationTests : BaseIntegrationTest
    {
        public ConfigurationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static ReportController SetupController(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<ReportGeneratorService>());
        }

        private static ReportController SetupControllerr(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<SendingReportService>());
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
           
            PdfDocument result = controller.GeneratePdf();

            Assert.NotNull(result);
        }
        /*

            [Fact]
            public void Generating_pdf_for_report()
            {

                using var scope = Factory.Services.CreateScope();
                var controller = SetupController(scope);

                PdfDocument result = controller.GeneratePdf(new Guid("e2ddfa02620e48e983824b23ac955632"));
                Assert.NotNull(result);
            }
            */
        [Fact]
            public void Sends_configuration_pdf()
        {
            

          

            var mocSend = new Mock<SendingReportService>();
            var controller = SetupControllerr((IServiceScope)mocSend.Object);
             
               
           // var response=controller.SendReport(controller.GeneratePdf());
            //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
    
    
    }
}
