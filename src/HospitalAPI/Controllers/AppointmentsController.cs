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
        private IAppointmentService appointmentService;
        private IDoctorService doctorService;

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
            } catch
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
            return Ok("Passed");
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

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAppointmentForReport(string id)
        {
            var app = _appointmentService.GetAppointmentForReport(id);
            return Ok(app);

            /*
            //Dana&Anja

            // GET: api/Appointments/patient/id
            [HttpGet("patient/{id}")]
            public ActionResult GetForPatient(string id)
            {
                return Ok(_availableAppointmentService.GetForPatient(id));
            }


            [HttpPost("patient/suggestions/{priority}")]
            public ActionResult AppointmentsWithSuggestions(AppointmentPatientDTO dto, string priority)
            {
                Doctor doctor = _doctorService.GetById(dto.DoctorId);
                dto.Doctor = doctor;
                var appointments = _availableAppointmentService.FindAppointmentsWithSuggestions(dto, priority);
                if (appointments == null)
                {
                    return NotFound();
                }

                return Ok(appointments);
            }

            [HttpPost("patient/AppAvailability")]
            public ActionResult CheckIfAvailable(AppointmentPatientDTO dto)
            {
                bool available = _availableAppointmentService.CheckAvailability(dto);
                if (available)
                {
                    return Ok();
                }
                return NotFound();

            }

            [HttpPost("patient/regularAppointments")]
            public ActionResult DateDoctorAppointments(AppointmentPatientDTO dto)
            {
                Doctor doctor = _doctorService.GetById(dto.DoctorId);
                dto.Doctor = doctor;

                var appointments = _availableAppointmentService.GetDoctorsAvailableAppointmentsForDate(dto.Doctor, DateTime.Parse(dto.DateString));

                if (appointments.IsNullOrEmpty())
                {
                    return NotFound();
                }
                return Ok(appointments);
            }


            [HttpPost]
            [Route("patient/schedule")]
            public ActionResult PatientSchedule(AppointmentPatientDTO dto)
            {

                CreateAppointmentDTO createDTO = dto.toCreateDTO();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _appointmentService.Create(createDTO);
                return NoContent();
            }*/
        }
    }
}
