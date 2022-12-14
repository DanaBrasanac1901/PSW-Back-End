using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.PatientAppointmentCancelation
{
    [Keyless]
    public class PatientAppointmentCancelation : ValueObject
    {
        public string PatientId { get; private set; }
        public DateTime CancelationDate { get; private set; }

        public PatientAppointmentCancelation() { }

        public PatientAppointmentCancelation(string patientId, DateTime cancelationDate){
            //Validate(patientId);
            PatientId = patientId;
            CancelationDate = cancelationDate;
        }
        //private void Validate(string patientId) {
        //    if (patientId.Substring(0, 3) != "PAT")
        //    {
        //        throw new ArgumentException();
        //    }
        //    else if(!Int32.TryParse(patientId.Substring(3), out int result)){
        //        throw new ArgumentException();
        //    }
        //}
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PatientId;
            yield return CancelationDate;
        }
    }
}