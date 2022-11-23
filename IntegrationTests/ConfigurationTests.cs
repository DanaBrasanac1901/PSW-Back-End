using System;
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

            Report result = new Report(Period.Daily, new Guid());
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Update_report()
        {
            
            
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Guid id = new Guid("9A76E313-E764-4B63-8544-5AAC14155C6A");
            Report result = controller.GetById(id);
            ReportDTO resultDTO = new ReportDTO(Period.EveryTwoMonths, result.Id);
            controller.Update(resultDTO);
            Assert.NotNull(result);

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

            // PdfDocument result = controller.GeneratePdf();
            
            PdfDocument result = _reportGeneratorService.GeneratePdf();
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
    
    
    
    }
}
