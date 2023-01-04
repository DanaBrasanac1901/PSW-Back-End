using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Doctor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core;
using System.Collections.Generic;
using Castle.Core.Internal;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.Patient.DTOS;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientHealthMeasurementsController : ControllerBase
    {
        private readonly IPatientHealthMeasurementsService _patientHealthMeasurementsService; 

        public PatientHealthMeasurementsController(IPatientHealthMeasurementsService patientHealthMeasurementsService)
        {
            _patientHealthMeasurementsService = patientHealthMeasurementsService;
        }

        // GET: api/appointments
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientHealthMeasurementsService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var phm = _patientHealthMeasurementsService.GetById(id);
            if (phm == null)
            {
                return NotFound();
            }

            return Ok(phm);
        }

        [HttpPost]
        [Route("SubmitPatientHealthMeasurements")]
        public ActionResult SubmitPatientHealthMeasurements(SubmitPatientHealthMeasurementsDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _patientHealthMeasurementsService.Create(dto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetPatientHealthMeasurements/{id}")]
        public ActionResult GetPatientHealthMeasurements(int id)
        {
            return Ok(_patientHealthMeasurementsService.GetPatientHealthMeasurements(id));
        }
    }
}
