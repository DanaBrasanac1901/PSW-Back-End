using Castle.Core.Internal;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Patient;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
     

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/patients
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientService.GetAll());
        }

        // GET api/patients/2
       
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
        // POST api/patients
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientService.Create(patient);
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }
        [HttpPost("login")]
        public ActionResult Login(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Patient logged=_patientService.CheckCreditentials(patient.Email,patient.Password);
            if (logged == null)
                return NotFound();
            return Ok(patient);
        }
        [HttpPost("validate/{id}")]
        public ActionResult Validate(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientService.Activate(patient);
            return Ok(patient);
        }
        [HttpPost("register")]
        public ActionResult Register(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientService.Register(patient);
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }

        // PUT api/patients/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.Id)
            {
                return BadRequest();
            }

            try
            {
                _patientService.Update(patient);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(patient);
        }

        // DELETE api/patients/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientService.Delete(patient);
            return NoContent();
        }

        [HttpGet("minimal-patients-doctor")]
        public ActionResult GetDoctorsWithLeastPatients() {

            var doctorIds = _patientService.GetDoctorsWithLeastPatients();
            if(doctorIds == null)
            {
                return NotFound();
            }

            return Ok(doctorIds);
        
        
        }
    }
}
