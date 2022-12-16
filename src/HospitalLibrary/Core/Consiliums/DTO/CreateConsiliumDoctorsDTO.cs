using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class CreateConsiliumDoctorsDTO
    {
        public string Topic { get; set; }
        public int Duration { get; set; }
        public string StartDate { get; set; }
        public string DoctorIds { get; set; }

        public CreateConsiliumDoctorsDTO()
        {
        }

        public CreateConsiliumDoctorsDTO(string topic, int duration, string startDate, string doctorIds)
        {
            Topic = topic;
            Duration = duration;
            StartDate = startDate;
            DoctorIds = doctorIds;
        }
    }
}