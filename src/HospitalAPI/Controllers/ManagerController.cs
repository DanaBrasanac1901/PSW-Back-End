using HospitalLibrary.Core.Manager;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagersController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        // GET: api/managers
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_managerService.GetAll());
        }

        // GET api/managers/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var manager = _managerService.GetById(id);
            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }

        // POST api/managers
        [HttpPost]
        public ActionResult Create(Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _managerService.Create(manager);
            return CreatedAtAction("GetById", new { id = manager.Id }, manager);
        }

        // PUT api/managers/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manager.Id)
            {
                return BadRequest();
            }

            try
            {
                _managerService.Update(manager);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(manager);
        }

        // DELETE api/managers/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var manager = _managerService.GetById(id);
            if (manager == null)
            {
                return NotFound();
            }

            _managerService.Delete(manager);
            return NoContent();
        }
    }
}
