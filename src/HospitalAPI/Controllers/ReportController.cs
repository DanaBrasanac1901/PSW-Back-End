using HospitalLibrary.Core.Report.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IDrugApplicationService _drugApplicationService;
        private readonly ISymptomApplicationService _symptomApplicationService;

        public ReportController(IDrugApplicationService drugApplicationService, ISymptomApplicationService symptomApplicationService)
        {
            _drugApplicationService = drugApplicationService;
            _symptomApplicationService = symptomApplicationService;
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


    }
}
