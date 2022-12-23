using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Blood.DTOS;
using System;

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

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetById(int id)
        {
            var record = _bloodService.GetById(id);
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateConsumptionRecord(BloodConsumptionRecordDTO record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BloodConsumptionRecord newRecord = BloodDTOAdapter.CreateConsmptionRecordDTOToObject(record);
            newRecord.Id = (int)DateTime.Now.Ticks;

            _bloodService.CreateBloodConsumptionRecord(newRecord);

            return CreatedAtAction("GetById", new { id = newRecord.Id }, newRecord);
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
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetByGroupA()
        {
            var record = _bloodService.GetByGroupA();
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetByGroupB()
        {
            var record = _bloodService.GetByGroupB();
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetByGroupAB()
        {
            var record = _bloodService.GetByGroupAB();
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetByGroupO()
        {
            var record = _bloodService.GetByGroupO();
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }


    }
}