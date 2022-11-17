using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HospitalLibrary.Core.Blood;
using IntegrationLibrary.BloodBank;
using MimeKit.Cryptography;

namespace IntegrationLibrary.Report
{
    public class ReportGeneratorService: BackgroundService
    {
        
        private readonly IReportRepository _reportRepository;

        private readonly IBloodBankRepository _bloodBankRepository;
        
        private readonly IBloodConsuptionRecordRepository _bloodConsuptionRecordRepository;

        private void ConsumptionAmount(Guid bloodBankId)
        {
            BloodBank.BloodBank bloodBank = _bloodBankRepository.GetById(bloodBankId);
            //treba nam info od koje je banke
            //isfiltriramo po bankama
            //poziv fje koja na osnovu configuration date i perioda bira dane kad je bilo potrosnje
            //pozovemo fju koja sabere potrosnju
            
            IEnumerable<BloodConsumptionRecord> bloodConsumpotion  = _bloodConsuptionRecordRepository.GetAll();
            
            //vrati int kolicinu
        }


        public ReportGeneratorService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }


        private void FindBloodBank(Guid id)
        {

        }

        private void SendReport()
        {
        }

        public void GeneratePdf(Guid reportId)
        {
            var generateReport = _reportRepository.GetById(reportId);
            var renderer = new IronPdf.ChromePdfRenderer
            {
                RenderingOptions =
                {
                    PaperSize = IronPdf.Rendering.PdfPaperSize.A2,
                    ViewPortWidth = 1280
                }
            };

            string reportHtml = Html(generateReport.BloodbankId);
            var pdf = renderer.RenderHtmlAsPdf(reportHtml);
            //pdf.SaveAs("src/IntegrationAPI/BBConnection/myPDF.pdf");
        }


        private string Html(Guid bloodBankId)
        {
            BloodBank.BloodBank bloodBank = _bloodBankRepository.GetById(bloodBankId);
            return "<h1>Report</h1> Report for week";
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}