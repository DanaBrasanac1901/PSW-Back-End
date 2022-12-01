using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public class InpatientTreatmentRecord
    {
        public string Id { get; set; }
        public string DoctorID { get; set; }
        public string PatientID { get; set; }
        public string RoomID { get; set; }
        public string BedID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool Status { get; set; }
        public string Therapy { get; set; }
        public string AdmissionReason { get; set; }
        public string DischargeReason { get; set; }
        public DateTime DischargeDate { get; set; }

        public InpatientTreatmentRecord() { }

        public InpatientTreatmentRecord(string id, string doctorID, string patientID, string roomID, string bedID, DateTime admissionDate, bool status, string therapy, string admissionReason, string dischargeReason, DateTime dischargeDate)
        {
            Id = id;
            DoctorID = doctorID;
            PatientID = patientID;
            RoomID = roomID;
            BedID = bedID;
            AdmissionDate = admissionDate;
            Status = status;
            Therapy = therapy;
            AdmissionReason = admissionReason;
            DischargeReason = dischargeReason;
            DischargeDate = dischargeDate;
        }
    }
}
