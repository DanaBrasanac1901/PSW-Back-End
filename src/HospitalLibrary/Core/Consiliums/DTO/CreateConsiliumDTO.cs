using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class CreateConsiliumDTO
    {
        public string Topic { get; set; }
        public int Duration { get; set; }
        public string StartDate { get; set; }
        public string DoctorIds { get; set; }

        public CreateConsiliumDTO()
        {
        }

        public CreateConsiliumDTO(string topic, int duration, string startDate, string doctorIds)
        {
            Topic = topic;
            Duration = duration;
            StartDate = startDate;
            DoctorIds = doctorIds;
        }
    }
}