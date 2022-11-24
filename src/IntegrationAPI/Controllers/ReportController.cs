using System;
using IntegrationLibrary.Report;
using IronPdf;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ReportGeneratorService _reportGeneratorService;
        private readonly SendingReportService _sendingReportService;
            public ReportController(IReportService reportService)
            {
                _reportService = reportService;
            }

        public ReportController(SendingReportService sendReporService)
        {
            _sendingReportService = sendReporService;
        }
        public ReportController(ReportGeneratorService reportGeneratorService)
            {
                _reportGeneratorService = reportGeneratorService;
            }

            // GET: api/reports ili bez s?
            [HttpGet]
            public ActionResult GetAll()
            {
                return Ok(_reportService.GetAll());
            }

            // GET api/reports/2
            [HttpGet("{id:guid}")]
            public ActionResult GetById(Guid id)
            {
                var report = _reportService.GetById(id);
                if (report == null)
                {
                    return NotFound();
                }

                return Ok(report);
            }

            // POST api/reports
            [HttpPost]
            public ActionResult Create(Report report)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _reportService.Create(report);
                return CreatedAtAction("GetById", new { id = report.Id }, report);
            }

            // PUT api/reports/2
            [HttpPut("{id}")]
            public ActionResult Update(Guid id, Report report)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != report.Id)
                {
                    return BadRequest();
                }

                try
                {
                    _reportService.Update(report);
                }
                catch
                {
                    return BadRequest();
                }

                return Ok(report);
            }


            
            [HttpPost("report")]
            public PdfDocument GeneratePdf(Guid id)
            {
               return  _reportGeneratorService.GeneratePdf(id);
            }
            
            //za test
            
            [HttpPost("report/test")]
            public PdfDocument GeneratePdf()
            {
                return _reportGeneratorService.GeneratePdf();
               
            }
    }
    }