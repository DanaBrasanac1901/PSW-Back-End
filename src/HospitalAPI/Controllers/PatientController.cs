﻿using HospitalLibrary.Core.Patient;
using Microsoft.AspNetCore.Mvc;

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
    }
}