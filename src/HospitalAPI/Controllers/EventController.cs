using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    public class EventController : ControllerBase
    {
        [HttpPost("patient/start")]
        public ActionResult PatientStart(DateTime timeStamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        [HttpPost("patient/back")]
        public ActionResult PatientBack(DateTime timeStamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

        [HttpPost("patient/next")]
        public ActionResult PatientNext(DateTime timeStamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

        [HttpPost("patient/schedule")]
        public ActionResult PatientSchedule(DateTime timeStamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
