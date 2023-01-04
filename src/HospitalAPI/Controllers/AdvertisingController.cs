using HospitalLibrary.Core.Advertising;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisingController : ControllerBase
    {
       // private readonly AdvertisingService _advertisingService;
        public AdvertisingController()
        {
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            //var ads = _advertisingService.GetAll();
           // if (ads == null) return NotFound();
            return Ok();

        }

    }
}
