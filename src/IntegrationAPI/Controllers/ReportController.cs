using System;
using IntegrationAPI.DTO;
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
        private readonly IReportGeneratorService _reportGeneratorService;
            public ReportController(IReportService reportService)
            {
                _reportService = reportService;
            }


            /*  public ReportController(ReportGeneratorService reportGeneratorService)
            {
                _reportGeneratorService = reportGeneratorService;
            }*/

            // GET: api/reports ili bez s?
            [HttpGet]
            public ActionResult GetAll()
            {
                return Ok(_reportService.GetAll());
            }

            // GET api/reports/2
            [HttpGet("{id:guid}")]
            public Report GetById(Guid id)
            {
                var report = _reportService.GetById(id);
               //Validate if Id == null

                return report;
            }

            // POST api/reports
            [HttpPost]
            public IActionResult Create([FromBody] ReportDTO report)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                _reportService.Create(report);
                return Ok();
            }

            // PUT api/reports/2 
            [HttpPut("{id}")]
            public ActionResult Update(ReportDTO reportDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    _reportService.Update(reportDto);
                }
                catch
                {
                    return BadRequest();
                }

                return Ok(reportDto);
            }


            
            [HttpPost("report")]
            public PdfDocument GeneratePdf(Guid id)
            {
               return  _reportGeneratorService.GeneratePdf(id);
            }
            
            //za test KAKO ISTeSTIRATI KAD NIJE U KONTROLERU
            
            [HttpPost("report/test")]
            public PdfDocument GeneratePdf()
            {
                return _reportGeneratorService.GeneratePdf();
               
            } 
    }
    }