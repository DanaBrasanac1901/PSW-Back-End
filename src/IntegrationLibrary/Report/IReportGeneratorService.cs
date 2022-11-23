using System;
using IronPdf;
using Microsoft.Extensions.Hosting;

namespace IntegrationLibrary.Report
{
    public interface IReportGeneratorService : IHostedService
    { 
        public PdfDocument GeneratePdf(Report reportId);

    }
}