using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalLibrary.Core.Vacation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InpatientTreatmentController : ControllerBase
    {
        private readonly IInpatientTreatmentRecordService _inpatientTreatmentService;

        public InpatientTreatmentController(IInpatientTreatmentRecordService inpatientTreatmentService)
        {
            _inpatientTreatmentService = inpatientTreatmentService;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetById(string id)
        {
            var request = _inpatientTreatmentService.GetById(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }




        


    }
}
