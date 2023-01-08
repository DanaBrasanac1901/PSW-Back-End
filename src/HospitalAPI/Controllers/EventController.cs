﻿using HospitalLibrary.Core.ApptSchedulingSession.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    public class EventController : ControllerBase
    {
        private readonly IScheduleAppointment _scheduleAppointment;
        public EventController(IScheduleAppointment scheduleAppointment) {
            _scheduleAppointment = scheduleAppointment;
        }

        [HttpPost("patient/start")]
        public ActionResult PatientStart(DateTime timeStamp)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _scheduleAppointment.Execute("start", timeStamp);
            return NoContent();
        }

        [HttpPost("patient/back")]
        public ActionResult PatientBack(DateTime timeStamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _scheduleAppointment.Execute("back", timeStamp);
            return NoContent();
        }

        [HttpPost("patient/next")]
        public ActionResult PatientNext(DateTime timeStamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _scheduleAppointment.Execute("next", timeStamp);
            return NoContent();
        }

        [HttpPost("patient/schedule")]
        public ActionResult PatientSchedule(DateTime timeStamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _scheduleAppointment.Execute("schedule", timeStamp);
            return NoContent();
        }
    }
}
