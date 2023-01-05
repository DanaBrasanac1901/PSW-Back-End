using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Doctor.DTOS;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

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

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_doctorService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet("specialty/{specialty}")]
        public ActionResult GetBySpecialty(string specialty)
        {
            var doctors = _doctorService.GetBySpecialty(specialty);
            if (doctors == null)
            {
                return NotFound();
            }

            return Ok(doctors);
        }
        
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

        [HttpPut("{id}")]
        public ActionResult Update(int id, Doctor doctor)
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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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
        public ActionResult GetDoctorShiftDTO(int id)
        {
            var doctor = _doctorService.GetDoctorsShiftById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet]
        [Route("[action]/{id}/{vacationStart}/{vacationEnd}")]
        public ActionResult GetDoctorsAppointmentsForVacation(int id, string vacationStart, string vacationEnd)
        {
            GetDoctorsAppointmentsForUrgentVacationDTO dto = new();
            dto.id = id;
            dto.vacationStart = vacationStart;
            dto.vacationEnd = vacationEnd;
            var apps = _doctorService.GetAppointmentsUrgentVacation(dto);
            if (apps == null)
            {
                return NotFound();
            }
            return Ok(apps);
        }

        [HttpGet]
        [Route("[action]/{startDate}/{startTime}")]
        public IActionResult GetDoctorsForRearrange(string startDate, string startTime)
        {
            List<DoctorToChangeUrgentVacationDTO> doctors = _doctorService.GetFreeDoctors(startDate, startTime);

            if (doctors == null)
            {
                return new CustomError(HttpStatusCode.BadRequest, "There are no available doctors, please choose another date span.");
            }

            return Ok(doctors);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult getFreeSpecialtyDoctors(CheckDateSpecialtyDTO dto)
        {
            var ret = _doctorService.GetFreeSpecialtyDoctors(dto.AppointmentDate, dto.Specialty);
            return Ok(ret);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult getSpecialtyDoctors(int specialty)
        {
            return Ok(_doctorService.GetSpecialtyDoctors(specialty));
        }

        public class CustomError : IActionResult
        {
            private readonly HttpStatusCode _status;
            private readonly string _errorMessage;

            public CustomError(HttpStatusCode status, string errorMessage)
            {
                _status = status;
                _errorMessage = errorMessage;
            }

            public async Task ExecuteResultAsync(ActionContext context)
            {
                var objectResult = new ObjectResult(new
                {
                    errorMessage = _errorMessage
                })
                {
                    StatusCode = (int)_status,
                };

                context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = _errorMessage;

                await objectResult.ExecuteResultAsync(context);
            }
        }
    }
}
