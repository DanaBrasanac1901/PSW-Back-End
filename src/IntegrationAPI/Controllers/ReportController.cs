using IntegrationLibrary.Report;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public void Generate()
        {
        }
    }
}