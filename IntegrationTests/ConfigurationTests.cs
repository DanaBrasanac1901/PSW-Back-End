using System;
using IntegrationAPI;
using IntegrationAPI.Controllers;
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

/*
        private static ReportController SetupController(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<ReportGeneratorService>());
        } */ 

        public static ReportGeneratorService _reportGeneratorService = new ReportGeneratorService();

        [Fact]
        public void Create_report()
        {

        }
        
        [Fact]
        public void Update_report()
        {

        }
        
        [Fact]
        public void Read_report()
        {

        }
        
        [Fact]
        public void Get_information_for_report()
        {

        }
        
        [Fact]
        public void Generating_pdf()
        {
            /* using var scope = Factory.Services.CreateScope();
             var controller = SetupController(scope);

             PdfDocument result = controller.GeneratePdf();
            */
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
