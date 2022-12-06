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

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IAvailableAppointmentService _availableAppointmentService;
  
        public AppointmentsController(IAvailableAppointmentService availableAppointmentService, IAppointmentService appointmentService, IDoctorService doctorService, IEmailSendService emailSend)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _availableAppointmentService = availableAppointmentService;
        }

        // GET: api/appointments
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }

        // GET: api/Appointments/patient/id
        [HttpPost("patient")]
        public ActionResult GetForPatient(AppointmentPatientDTO dto)
        {
            // This SHOULD be a get but this is the only way i can force swagger to recognize my DTO in schemas
            return Ok(_availableAppointmentService.GetForPatient(dto.DoctorName));
        }

        [HttpGet("doctors/{date}/{specialty}")]
        public ActionResult GetSpecialtyDoctorsForDate(DateTime date, Specialty specialty)
        {
            var doctors = _availableAppointmentService.GetDoctorsByDateAndSpecialty(date, specialty);
            if(doctors == null)
            {
                return NotFound();
            }
            return Ok(doctors);

        }

        [HttpGet("suggestions/{dateRange}/{doctor}/{priority}")]
        public ActionResult AppointmentsWithSuggestions(DateTimeRange dateRange, Doctor doctor, string priority)
        {
            var appointments = _availableAppointmentService.FindAppointmentsWithSuggestions(dateRange, doctor, priority);
            if(appointments == null)
            {
                return NotFound();
            }
            return Ok(appointments);
        }

        [HttpGet("regular/{date}/{doctor}")]
        public ActionResult DateDoctorAppointments(DateTime date, Doctor doctor)
        {
            List<AppointmentPatientDTO> appointments = new List<AppointmentPatientDTO>();
            _availableAppointmentService.GetDoctorsAvailableAppointmentsForDate(doctor, date, appointments);
            if (appointments.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(appointments);
        }



        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }


        [HttpPost]
        public ActionResult Create(CreateAppointmentDTO appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appointmentService.Create(appointmentDTO);
            Appointment appointment = new Appointment();
            return NoContent();
        }

        // PUT api/appointments/2
        [HttpPut("{id}")]
        public ActionResult Update(RescheduleAppointmentDTO appointmentDTO)
        {
            //Console.WriteLine("MAMA DOBRO SAM!");
            //Appointment appointment = _appointmentService.GetById(appointmentDTO.id);
            //string timeParse = appointmentDTO.date + " " + appointmentDTO.time + ":00";
            //DateTime newStartTime = Convert.ToDateTime(timeParse);
            ////appointment.Start = newStartTime;
            //Boolean flag1 = _appointmentService.CheckIfAppointmentIsSetInFuture(newStartTime);
            //Boolean flag2 = _appointmentService.IsAvailableDateOnly(newStartTime,appointment.DoctorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                _appointmentService.Update(appointmentDTO);
            }catch
            {
                return BadRequest();
            }
            return Ok(appointmentDTO);
        }

        // DELETE api/appointments/2
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {


            var appointment = _appointmentService.GetById(id);
            

            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Delete(id);
            return NoContent();
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateAppointment(CreateAppointmentDTO appDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string idFlag = _appointmentService.Create(appDTO);
            return CreatedAtAction("GetById", new { id = idFlag }, appDTO);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAllByDoctor(string id)
        {
            var appointments = _appointmentService.GetAllByDoctor(id);
            if (appointments == null)
                return NotFound();

            return Ok(appointments);

        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAppToReschedule(string id)
        {
            var appointment = _appointmentService.GetAppoitnemtnToReschedule(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        [Route("[action]/{doctorId}/{appointmentId}")]
        public ActionResult ChangeDoctorForAppointment(string doctorId, string appointmentId)
        {
            _appointmentService.ChangeDoctorForAppointment(doctorId, appointmentId);
            return Ok();
        }
    }
}
