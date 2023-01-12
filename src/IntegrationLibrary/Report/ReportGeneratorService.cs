using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using HospitalLibrary.Core.Blood;
using IntegrationAPI.DTO;
using IntegrationLibrary.BloodBank;
using IronPdf;
using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;

namespace IntegrationLibrary.Report
{
    public class ReportGeneratorService: IReportGeneratorService
    {
        
        private readonly IReportService _reportService;
        private readonly IBloodBankService _bloodBankService;
        private readonly IBloodService _bloodService;

        public ReportGeneratorService(IReportService reportService, 
            IBloodBankService bloodBankService)
        {
            _reportService = reportService;
            _bloodBankService = bloodBankService;
           // _bloodService = bloodService;

        }

        //glavna fja
        public void GeneratePdf()
        {
            foreach (var report in _reportService.GetAll())
            {
               GeneratePdf(report);
            }
        }

       
        //odvojeno pozvana za test
        public bool GeneratePdf(Report report)
        {

            if (report.LastReportGeneration.AddDays(PeriodConverter.Convert(report.Period)) == DateTime.Today)
            {
                var renderer = new ChromePdfRenderer
                {
                    RenderingOptions =
                    {
                        PaperSize = IronPdf.Rendering.PdfPaperSize.A2,
                        ViewPortWidth = 1280
                    }
                };

                var reportHtml = Html(report);
                var pdf = renderer.RenderHtmlAsPdf(reportHtml);
                //$"report{report.Id}.pdf"
                pdf.SaveAs("report.pdf");

                report.LastReportGeneration = DateTime.Today;
                _reportService.Update(ReportDtoAdapter.NewReportDto(report));

                
                // fja za slanje
                
                return true;
            }

            else return false;
        }



        private string Html(Report report)
        {
            BloodBank.BloodBank bloodBank = _bloodBankService.GetById(report.Id);

            //return $"<h1>Report </h1> Report for {bloodBank.Username} week {DateTime.Now}";
            return "nesto";
                //+ $" Spent {ConsumptionForBank(bloodBank.Id)} ";
        }
     

/*
       private double ConsumptionForBank(Guid bloodBankId)
        {
            double consumption = 0;
            List<BloodConsumptionRecord> matchedRecords = new List<BloodConsumptionRecord>();
            foreach (var bloodConsumption in _bloodService.GetAll())
            {
                if (bloodConsumption.SourceBank == bloodBankId)
                {
                    matchedRecords.Add(bloodConsumption);
                }
               
            }
            
             consumption =  FindConsumptionForBloodBank(bloodBankId, matchedRecords);
            return consumption;
        }

        private double FindConsumptionForBloodBank(Guid bloodBankId, List<BloodConsumptionRecord> matchedRecords)
        {
            var report = _reportService.GetById(bloodBankId);
            double consumption = 0;
            
            foreach (var bloodConsumptionRecord in matchedRecords)
            {
                //ako spada record u period
                
                if (bloodConsumptionRecord.CreatedAt <
                    report.LastReportGeneration.AddDays(PeriodConverter.Convert(report.Period)) &&
                    bloodConsumptionRecord.CreatedAt > report.LastReportGeneration)
                {
                    consumption += (bloodConsumptionRecord.Amount);
                }
            }

            return consumption;
        } 


      */
 
    }
   
  
}