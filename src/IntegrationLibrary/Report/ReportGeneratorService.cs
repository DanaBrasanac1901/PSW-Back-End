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
        public Report Report=  new Report();
        public BloodBank.BloodBank BloodBank = new BloodBank.BloodBank();

        public ReportGeneratorService(IReportRepository reportRepository, 
            IBloodBankRepository bloodBankRepository, IBloodConsuptionRecordRepository bloodRepository)
        {
            _reportRepository = reportRepository;
            _bloodBankRepository = bloodBankRepository;
            _bloodRepository = bloodRepository;
            _allReports = _reportRepository.GetAll();
        }

        
        protected Task ExecuteAsync(CancellationToken stoppingToken)
        {
            foreach (Report report in _allReports)
            {
                GeneratePdf(report);
            }

            return Task.CompletedTask;
        }
        
        public PdfDocument GeneratePdf(Report report)
        {

            foreach (Report matchedReport in _allReports)
            {
                if (matchedReport.Id == report.Id)
                {
                    Report = matchedReport;
                }
            }
            
            
            var renderer = new IronPdf.ChromePdfRenderer
            {
                RenderingOptions =
                {
                    PaperSize = IronPdf.Rendering.PdfPaperSize.A2,
                    ViewPortWidth = 1280
                }
            };

            string reportHtml = Html(Report);
            var pdf = renderer.RenderHtmlAsPdf(reportHtml);
            
            String pdfName = Report.Id.ToString() + "report.pdf";
            pdf.SaveAs(pdfName);
            
            Report.LastReportGeneration = DateTime.Today;
            _reportRepository.Update(Report);
            return pdf;
            
        }
        
        
        
        private string Html(Report report)
        {
            if (_bloodBankRepository.GetById(report.Id) != null)
            {
                //{bloodBank.Username}
                return $"<h1>Report </h1> Report for week ";
            }

            else 
                return  $"<h1>Bloodbank not found</h1> Report for week ";
            //+ $" Spent {ConsumptionAmount(bloodBank.Id)} ";
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

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //ako se poklopilo datum last generisanja + perioda i danasnji
          //  TodayIsTheDay == true;
          
          throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //  TodayIsTheDay == false;
            throw new NotImplementedException();
        }
    }

  
}