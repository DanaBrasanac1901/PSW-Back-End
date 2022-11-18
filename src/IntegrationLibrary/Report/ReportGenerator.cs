using System;

namespace IntegrationLibrary.Report
{
    public class ReportGenerator
    {
        
        private readonly IReportRepository _reportRepository;
        public void GeneratePDF(Guid id)
        {
            Report generateReport = _reportRepository.GetById(id);
            var Renderer = new IronPdf.ChromePdfRenderer();
            Renderer.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A2;
            Renderer.RenderingOptions.ViewPortWidth = 1280;

            var pdf = Renderer.RenderHtmlAsPdf("<h1>Report</h1> Report for week ");
            pdf.SaveAs("src/IntegrationAPI/BBConnection/myPDF.pdf");
            //  return File(doc.Stream.ToArray(), "application/pdf");
        }
    }
}