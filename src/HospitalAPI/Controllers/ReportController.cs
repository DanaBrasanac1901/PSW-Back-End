using HospitalLibrary.Core.Report;
using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Services;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Report.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportApplicationService _reportApplicationService;
        private readonly IDrugApplicationService _drugApplicationService;
        private readonly ISymptomApplicationService _symptomApplicationService;

        public ReportController(IDrugApplicationService drugApplicationService, ISymptomApplicationService symptomApplicationService
        ,IReportApplicationService reportApplicationService)
        {
            _drugApplicationService = drugApplicationService;
            _symptomApplicationService = symptomApplicationService;
            _reportApplicationService = reportApplicationService;
        }

        public ReportController(IReportApplicationService reportApplicationService)
        {
            _reportApplicationService = reportApplicationService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAllDrugs()
        {
            return Ok(_drugApplicationService.GetAll());
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAllSymptoms()
        {
            return Ok(_symptomApplicationService.GetAllSymptoms());
        }


        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            return Ok(_reportApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var report = _reportApplicationService.GetById(id);
            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateReport(ReportToCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _reportApplicationService.Create(dto);
           
            return Ok("Passed");
        }

        [HttpPut("{id}")]
        public ActionResult Update(Report report)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _reportApplicationService.Update(report);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(report);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var report = _reportApplicationService.GetById(id);
            if (report == null)
            {
                return NotFound();
            }

            _reportApplicationService.Delete(report);
            return NoContent();
        }

    }
}
