using System;
using AutoMapper;
using IntegrationAPI.DTO;
using IntegrationLibrary.BloodBank;
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
        private readonly IMapper _mapper;
        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

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
        public IActionResult Create([FromBody] ReporttDTO reportt)
        {
            var report = _mapper.Map<ReportDTO>(reportt);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _reportService.Create(report);
            return Ok();
        }

        // PUT api/reports/2 
        [HttpPut("{id}")]
        public ActionResult Update(ReportDTO reportdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _reportService.Update(reportdto);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(reportdto);
        }

    }

}
   