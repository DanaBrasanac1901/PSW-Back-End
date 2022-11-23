using HospitalLibrary.Core.Equipment;
using HospitalLibrary.Core.InpatientTreatmentRecord;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAvailableRoomBeds(int id)
        {
            return Ok(_equipmentService.GetAvailableRoomBeds(id));
        }

        [HttpPut]
        [Route("[action]/{id}/{status}")]
        public ActionResult ChangeBedStatus(string id, int status)
        {
            return Ok(_equipmentService.ChangeBedStatus(id, status));
        }


    }
}