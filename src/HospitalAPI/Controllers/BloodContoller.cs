using HospitalLibrary.Core.Room;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Blood.DTOS;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodController : ControllerBase
    {
        private readonly IBloodService _bloodService;

        public BloodController(IBloodService bloodService)
        {
            _bloodService = bloodService;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateConsumptionRecord(CreateConsmptionRecordDTO record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bloodService.CreateBloodConsumptionRecord(record);
            return Ok(record);
        }
        
        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateBloodRequest(CreateBloodRequestDTO bloodRequest )
        {
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }
            else if(bloodRequest.amount<=0)
            {
                return BadRequest();
            }

            _bloodService.CreateBloodRequest(bloodRequest);
            return Ok();
        }



    }
}