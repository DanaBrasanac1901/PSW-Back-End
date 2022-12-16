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
        private readonly IDrugListApplicationService _drugListApplicationService;
        private readonly IDrugPrescriptionApplicationService _drugPrescriptionApplicationService;

        public ReportController(IDrugApplicationService drugApplicationService, ISymptomApplicationService symptomApplicationService
        ,IReportApplicationService reportApplicationService, IDrugListApplicationService drugListApplicationService
        ,IDrugPrescriptionApplicationService drugPrescriptionApplicationService)
        {
            _drugApplicationService = drugApplicationService;
            _symptomApplicationService = symptomApplicationService;
            _reportApplicationService = reportApplicationService;
            _drugListApplicationService= drugListApplicationService;
            _drugPrescriptionApplicationService = drugPrescriptionApplicationService;
        }



        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAllDrugs()
        {
            return Ok(_drugListApplicationService.GetAllDrugList());
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
           
            return Ok(dto);
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

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetReportById(string id)
        {
            var report = _reportApplicationService.GetReportToShow(id);
            return Ok(report);
        }

        //[HttpGet]
        //[Route("[action]/{id}")]
        //public ActionResult GetPrescriptionById(string id)
        //{
        //    var drugPres = _drugPrescriptionApplicationService.GetDrugPrescriptionToShow(id);
        //    return Ok(drugPres);
        //}

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetDrugFromReport(string id)
        {
            var drugPres = _reportApplicationService.GetDrugToShow(id);
            return Ok(drugPres);
        }



    }
}
