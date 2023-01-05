using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord.DTO
{
    public class DischargeTreatmentDTO
    {
        //public string patientName { get; set; }
        //public string patientSurname { get; set; }

        public string id { get; set; }
        public int patientId { get; set; }
        public string roomId { get; set; }
        public string bedId { get; set; }

        public string therapy { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string reason { get; set; }

        public DischargeTreatmentDTO() { }
    }
}
