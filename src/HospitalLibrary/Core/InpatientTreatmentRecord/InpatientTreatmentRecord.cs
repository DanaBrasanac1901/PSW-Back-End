using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public class InpatientTreatmentRecord
    {
        public string RecordID { get; set; }
        public string DoctorID { get; set; }
        public string PatientID { get; set; }
        public string RoomID { get; set; }
        public string BedID { get; set; }
        public DateTime AdmissionTime { get; set; }
        public Boolean Status { get; set; }
        public string Therapy { get; set; }
        public DateTime DischargeTime { get; set; }
    }
}
