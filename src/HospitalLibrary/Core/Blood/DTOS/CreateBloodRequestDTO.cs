using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.Core.Blood.DTOS
{
    public class CreateBloodRequestDTO
    {
        public int id { get; set; }

        public string doctorId { get; set; }

        public BloodType type { get; set; }

        public double amount { get; set; }

        public string reason { get; set; }

        public string due { get; set; }

        public CreateBloodRequestDTO()
        {

        }
    }
}