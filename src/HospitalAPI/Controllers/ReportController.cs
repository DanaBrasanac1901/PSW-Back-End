using HospitalLibrary.Core.Report;
using HospitalLibrary.Core.Report.Services;
using Microsoft.AspNetCore.Mvc;

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



        public ActionResult GetAll()
        {
            return Ok(_reportApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        [Route("[action]")]
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
        public ActionResult CreateReport(Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _reportApplicationService.Create(report);
           
            return Ok();
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
