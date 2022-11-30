using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class CreateConsiliumDTO
    {
        public string topic { get; set; }
        public int duration { get; set; }
        public string startDate { get; set; }
        public string doctorIds { get; set; }

        public CreateConsiliumDTO()
        {
        }
    }
}