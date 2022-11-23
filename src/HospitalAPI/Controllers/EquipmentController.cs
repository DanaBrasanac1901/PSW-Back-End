using HospitalLibrary.Core.Equipment;
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

        
    }
}