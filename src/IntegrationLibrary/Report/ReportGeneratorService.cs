using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using HospitalLibrary.Core.Blood;
using IntegrationLibrary.BloodBank;
using IronPdf;
using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;

namespace IntegrationLibrary.Report
{
    public class ReportGeneratorService: IReportGeneratorService
    {
        
        private readonly IReportRepository _reportRepository;
        private readonly IBloodBankRepository _bloodBankRepository;
        
        private readonly IBloodConsuptionRecordRepository _bloodRepository;
        private IEnumerable<Report> _allReports = new List<Report>();
        private PdfDocument _report;

        public ReportGeneratorService(IReportRepository reportRepository, 
            IBloodBankRepository bloodBankRepository, IBloodConsuptionRecordRepository bloodRepository)
        {
            _reportRepository = reportRepository;
            _bloodBankRepository = bloodBankRepository;

            _bloodRepository = bloodRepository;
            _allReports = _reportRepository.GetAll();
        }

        public ReportGeneratorService()
        {
        }

        private double ConsumptionAmount(Guid reportId)
        {
            
            //int totalCount = _bloodRepository.GetForBank();

            return   CalculateForPeriod(reportId);
        }

        private double CalculateForPeriod(Guid reportId)
        {
            Report report = _reportRepository.GetById(reportId);
            double consumption = 0;

            
            //lista svih bloodConsumptiona
            foreach (BloodConsumptionRecord bloodConsumption in _bloodRepository.GetAll())
            {
                //ako se matchuju id reporta i u recordu
                if (bloodConsumption.CreatedAt <
                    report.LastReportGeneration + ConvertPeriodToTimeSpan(report.Period) &&
                    bloodConsumption.CreatedAt > report.LastReportGeneration)
                 {
                   consumption += (bloodConsumption.Amount); 
                 } 
            }
            
            return consumption;

        }

        private TimeSpan ConvertPeriodToTimeSpan(Period period)
        {
            if (period == Period.Daily)
            {
                return TimeSpan.FromDays(1);
            }
            else if (period == Period.Monthly)
            {
                return TimeSpan.FromDays(30);
            }
            else
            {
                return TimeSpan.FromDays(240);
            }

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

            PdfDocument pdf = renderer.RenderHtmlAsPdf("<h1>Report</h1> Report for week hellloo ");
          
            pdf.SaveAs( "report.pdf");
            
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

            string reportHtml = Html(generateReport.Id);
            var pdf = renderer.RenderHtmlAsPdf(reportHtml);
            
            String pdfName = generateReport.Id.ToString() + "report.pdf";
            pdf.SaveAs(pdfName);
            generateReport.LastReportGeneration = DateTime.Today;
            _reportRepository.Update(generateReport);
            return pdf;
            
        }


        private string Html(Guid reportId)
        {
            BloodBank.BloodBank bloodBank = _bloodBankRepository.GetById(reportId);
            return $"<h1>Report {bloodBank.Username}</h1> Report for week " +
                   $" Spent {ConsumptionAmount(bloodBank.Id)} ";
        }

     

        protected async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            foreach (Report report in _reportRepository.GetAll())
            {
                GeneratePdf(report.Id);
            }
        }
        /// <summary>Triggered when the application host is ready to start the service.</summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
       
      

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //ako se poklopilo datum last generisanja + perioda i danasnji
            throw new NotImplementedException();
        }

        /// <summary>Triggered when the application host is performing a graceful shutdown.</summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

  
}