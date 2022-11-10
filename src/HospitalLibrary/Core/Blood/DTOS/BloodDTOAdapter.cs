using HospitalLibrary.Core.Appointment.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood.DTOS
{
    public class BloodDTOAdapter
    {
        public static BloodConsumptionRecord CreateConsmptionRecordDTOToObject(BloodConsumptionRecordDTO record)
        {
            BloodConsumptionRecord recordTransformed = new BloodConsumptionRecord();

            recordTransformed.Amount = record.Amount;
            recordTransformed.Type = record.Type;
            recordTransformed.Reason = record.Reason;
            recordTransformed.CreatedAt = DateTime.Now;
            //get the currently logged in doctor and set his id
            recordTransformed.DoctorId = "DOC1";

            return recordTransformed;
        }

        public static BloodRequest CreateBloodRequestDTOToObject(CreateBloodRequestDTO newBloodRequest)
        {
           BloodRequest bloodRequestTransformed= new BloodRequest();

            bloodRequestTransformed.Id = newBloodRequest.id;
            bloodRequestTransformed.DoctorId = "DOC1";
            bloodRequestTransformed.Type = newBloodRequest.type;
            bloodRequestTransformed.Amount = newBloodRequest.amount;
            bloodRequestTransformed.Reason = newBloodRequest.reason;
            newBloodRequest.due = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            bloodRequestTransformed.Due =Convert.ToDateTime(newBloodRequest.due);
            

            return bloodRequestTransformed;

        }

    }
}
