using HospitalLibrary.Core.Vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord.DTO
{
    public class CreateInpatientTretmentRecordDTO
    {
        private IInpatientTreatmentRecordService inpatientTreatmentService;
        public int doctorId { get; set; }
        public int patientId { get; set; }
        public string roomId { get; set; }
        public string bedId { get; set; }
        public string AdmissionReason { get; set; }
        public string Therapy { get; set; }

        public CreateInpatientTretmentRecordDTO() { }

        public CreateInpatientTretmentRecordDTO(IInpatientTreatmentRecordService inpatientTreatmentService)
        {
            doctorId = 1;
            bedId = "B1";
            roomId = "1";
            Therapy = "terapija neka";
            AdmissionReason = "bolestan covek";

            this.inpatientTreatmentService = inpatientTreatmentService;
        }

    }
}
