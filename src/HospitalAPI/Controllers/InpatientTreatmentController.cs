using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalLibrary.Core.InpatientTreatmentRecord.DTO;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Vacation.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InpatientTreatmentController : ControllerBase
    {
        private readonly IInpatientTreatmentRecordService _inpatientTreatmentService;
        private readonly IEquipmentService _equipmentService;

        public InpatientTreatmentController(IInpatientTreatmentRecordService inpatientTreatmentService, IEquipmentService equipmentService)
        {
            _inpatientTreatmentService = inpatientTreatmentService;
            _equipmentService = equipmentService;
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

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateRequest(CreateInpatientTretmentRecordDTO record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            InpatientTreatmentRecord newRecord = InpateintTreatmentRecordDTOAdapter.InpatientTreatmentRecordDTOToObject(record);
            newRecord.Id = _inpatientTreatmentService.GenerateStringID();
            newRecord.DischargeDate.AddDays(30);

            _inpatientTreatmentService.Create(newRecord);

            _equipmentService.ChangeBedStatus(newRecord.BedID, 0);

            return CreatedAtAction("GetById", new { id = newRecord.Id }, newRecord);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAllWithStatusTrue()
        {
            return Ok(_inpatientTreatmentService.GetAllWithStatusTrue());
        }

        [HttpPut]
        [Route("[action]/{id}/{reason}")]
        public ActionResult Discharge(string id, string reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                InpatientTreatmentRecord record = _inpatientTreatmentService.GetById(id);
                record.DischargeReason = reason;
                _inpatientTreatmentService.Discharge(id);

                _equipmentService.ChangeBedStatus(record.BedID, 1);

                return Ok(record);
            }
        }

        [HttpPut]
        [Route("[action]/{id}/{therapy}")]
        public ActionResult UpdateTherapy(string id, string therapy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InpatientTreatmentRecord record = _inpatientTreatmentService.GetById(id);
            record.Therapy = therapy;
            _inpatientTreatmentService.Update(record);
            return Ok(record);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAllByDoctor(string id)
        {
            return Ok(_inpatientTreatmentService.GetAllByDoctor(id));   
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetRecordForDishcarged(string id)
        {
            return Ok(_inpatientTreatmentService.GetRecordForDischarged(id));
        }
    }
}
