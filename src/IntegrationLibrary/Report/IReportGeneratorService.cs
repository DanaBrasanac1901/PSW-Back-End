using System;
using IronPdf;
using Microsoft.Extensions.Hosting;

namespace IntegrationLibrary.Report
{
    public interface IReportGeneratorService
    {
        void GeneratePdf();

        //za test 
        bool GeneratePdf(Report report);
    }
}