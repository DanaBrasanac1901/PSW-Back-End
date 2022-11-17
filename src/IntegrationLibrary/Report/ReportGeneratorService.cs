using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HospitalLibrary.Core.Blood;
using IntegrationLibrary.BloodBank;
using IronPdf;
using Microsoft.EntityFrameworkCore;
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
          //  BloodBank.BloodBank bloodBank = _bloodBankRepository.GetById(bloodBankId);
            //treba nam info od koje je banke
            //isfiltriramo po bankama
            //poziv fje koja na osnovu configuration date i perioda bira dane kad je bilo potrosnje
            //pozovemo fju koja sabere potrosnju
            
            IEnumerable<BloodConsumptionRecord> bloodConsumpotion  = _bloodConsuptionRecordRepository.GetAll();
            
            //vrati int kolicinu
        }


        public ReportGeneratorService(IReportRepository reportRepository, IBloodBankRepository bloodBankRepository, IBloodConsuptionRecordRepository bloodConsuptionRecordRepository)
        {
            _reportRepository = reportRepository;
            _bloodBankRepository = bloodBankRepository;
            _bloodConsuptionRecordRepository = bloodConsuptionRecordRepository;
        }

        
        //za test
        public PdfDocument GeneratePdf()
        {
            ChromePdfRenderer renderer = new IronPdf.ChromePdfRenderer
            {
                RenderingOptions =
                {
                    PaperSize = IronPdf.Rendering.PdfPaperSize.A2,
                    ViewPortWidth = 1280
                }
            };

            PdfDocument pdf = renderer.RenderHtmlAsPdf("<h1>Report</h1> Report for week ");
            pdf.SaveAs("report.pdf");
            
            return pdf;
        }
        
        
        
        public PdfDocument GeneratePdf(Guid reportId)
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
            pdf.SaveAs("src/IntegrationAPI/BBConnection/report.pdf");
            generateReport.LastReportGeneration = DateTime.Today;
            _reportRepository.Update(generateReport);
            return pdf;
            
        }


        private string Html(Guid bloodBankId)
        {
            BloodBank.BloodBank registeredBloodBank = IsBloodBankRegistered(bloodBankId);
            if (registeredBloodBank == null)
            {
                
                return "<h1>Report</h1> BloodBank not found ";
                
            }

           //int totalCount = _bloodConsuptionRecordRepository.GetForBank();
           //CalculateForPeriod(report.LastReportGeneration, report.Period, bloodbankId);
           return $"<h1>Report {registeredBloodBank.Username}</h1> Report for week  ";
        }

        private BloodBank.BloodBank IsBloodBankRegistered(Guid bloodBankId)
        {
            foreach (BloodBank.BloodBank bloodBank in _bloodBankRepository.GetAll())
            {
                if (bloodBank.Id != null)
                {
                    return null;
                }
            }

            return _bloodBankRepository.GetById(bloodBankId);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }

  
}