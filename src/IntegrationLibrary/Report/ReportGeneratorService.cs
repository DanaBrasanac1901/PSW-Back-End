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
       // private readonly IBloodConsuptionRecordRepository _bloodRepository;

        public ReportGeneratorService(IReportRepository reportRepository, 
            IBloodBankRepository bloodBankRepository)
        {
            _reportRepository = reportRepository;
            _bloodBankRepository = bloodBankRepository;
           // _bloodRepository = bloodRepository;
        
        }

        //glavna fja
        public void GeneratePdf()
        { 
            foreach (var report in _reportRepository.GetAll())
            {
                GeneratePdf(report);
            }
        }

       
        //odvojeno pozvana za test
        public bool GeneratePdf(Report report)
        {

            var reportForGenerating = _reportRepository.GetById(report.Id);

            if (reportForGenerating.LastReportGeneration + PeriodConverter.Convert(reportForGenerating.Period) ==
                DateTime.Today)
            {
                var renderer = new IronPdf.ChromePdfRenderer
                {
                    RenderingOptions =
                    {
                        PaperSize = IronPdf.Rendering.PdfPaperSize.A2,
                        ViewPortWidth = 1280
                    }
                };

                var reportHtml = Html(reportForGenerating);
                var pdf = renderer.RenderHtmlAsPdf(reportHtml);

                var pdfName = reportForGenerating.Id + "report.pdf";
                pdf.SaveAs(pdfName);

                reportForGenerating.LastReportGeneration = DateTime.Today;
                _reportRepository.Update(reportForGenerating);

                //SALJI DALJE PDF
                return true;
            }

            else return false;
        }



        private string Html(Report report)
        {
            if (_bloodBankRepository.GetById(report.Id) != null)
            {
                //{bloodBank.Username}
                return $"<h1>Report </h1> Report for week ";
                //+ $" Spent {ConsumptionForBank(bloodBank.Id)} ";
            }

            else 
                return  $"<h1>Bloodbank not found</h1> Report for week ";
      
        }
     

/*
       private double ConsumptionForBank(Guid bloodBankId)
        {
            double consumption = 0;
            List<BloodConsumptionRecord> matchedRecords = new List<BloodConsumptionRecord>();
            foreach (var bloodConsumption in _bloodRepository.GetAll())
            {
                if (bloodConsumption.SourceBank == bloodBankId)
                {
                    matchedRecords.Add(bloodConsumption);
                    consumption =  FindConsumptionForBloodBank(bloodBankId, matchedRecords);
                }
               
            }

            return consumption;
        }

        private double FindConsumptionForBloodBank(Guid bloodBankId, List<BloodConsumptionRecord> matchedRecords)
        {
            var report = _reportRepository.GetById(bloodBankId);
            double consumption = 0;
            
            foreach (var bloodConsumptionRecord in matchedRecords)
            {
                //ako spada record u period
                
                if (bloodConsumptionRecord.CreatedAt <
                    report.LastReportGeneration + ConvertPeriodToTimeSpan(report.Period) &&
                    bloodConsumptionRecord.CreatedAt > report.LastReportGeneration)
                {
                    consumption += (bloodConsumptionRecord.Amount);
                }
            }

            return consumption;
        } */


      
 
    }
   
  
}