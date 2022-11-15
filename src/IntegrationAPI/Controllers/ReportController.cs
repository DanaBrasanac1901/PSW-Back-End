using System;
using IntegrationLibrary.Report;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ReportGenerator _reportGenerator;
            public ReportController(IReportService reportService)
            {
                _reportService = reportService;
            }

            // GET: api/reports ili bez s?
            [HttpGet]
            public ActionResult GetAll()
            {
                return Ok(_reportService.GetAll());
            }

            // GET api/reports/2
            [HttpGet("{id}")]
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


            public void GeneratePDF(Guid id)
            {
                _reportGenerator.GeneratePDF(id);
            }
    }
    }