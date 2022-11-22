using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Doctor.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_doctorService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }
        [HttpPost("login")]
        public ActionResult Login(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _doctorService.CheckCreditentials(doctor.Email, doctor.Password);
            return Ok(doctor);
        }

        //GET api/doctorNestoDTO/DOC1
        //[HttpGet("{id}")]
        //public ActionResult GetDoctorForShift(string id)
        //{
        //    DoctorShiftDTO doctorsShiftDTO = _doctorService.GetById(id);
        //    if (doctorsShiftDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(doctorsShiftDTO);
        //}

        // POST api/rooms
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _doctorService.Create(doctor);
            return CreatedAtAction("GetById", new { id = doctor.Id }, doctor);
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(string id, Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.Id)
            {
                return BadRequest();
            }

            try
            {
                _doctorService.Update(doctor);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(doctor);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _doctorService.Delete(doctor);
            return NoContent();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetDoctorShiftDTO(string id)
        {
            var doctor = _doctorService.GetDoctorsShiftById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }
    }
}
