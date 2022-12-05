using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalLibrary.Core.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class CreateConsiliumDTO
    {
        private IConsiliumService consiliumService;
        public string topic { get; set; }
        public int duration { get; set; }
        public string startDate { get; set; }
        public string doctorIds { get; set; }

        public CreateConsiliumDTO()
        {

        }

        public CreateConsiliumDTO(IConsiliumService consiliumService)
        {
            topic = "Okupljanje";
            duration = 60;
            startDate = "10/12/2022";
            doctorIds = "DOC1,DOC2";
            this.consiliumService = consiliumService;
        }
    }
}