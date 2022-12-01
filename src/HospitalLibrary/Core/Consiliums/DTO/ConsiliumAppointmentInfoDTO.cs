﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class ConsiliumAppointmentInfoDTO
    {
        public string Start { get; set; }
        public string End { get; set; }
        public int Duration { get; set; }
        public string DoctorIds { get; set; }

        public ConsiliumAppointmentInfoDTO() { }
        public ConsiliumAppointmentInfoDTO(DateTimeRange appointmentTime, int duration=0, string doctorIds="")
        {
            Start = appointmentTime.GetStartString();
            End = appointmentTime.GetEndString();
            Duration = duration;
            DoctorIds = doctorIds;
        }
    }
}
