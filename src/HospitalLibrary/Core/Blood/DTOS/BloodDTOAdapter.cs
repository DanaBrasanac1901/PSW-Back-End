using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Enums;
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

            recordTransformed.Amount = record.amount;
           
            recordTransformed.Reason = record.reason;
            //string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            recordTransformed.CreatedAt = DateTime.Now;
            //get the currently logged in doctor and set his id
            recordTransformed.DoctorId = "DOC1";
            if (record.type == "A")
                recordTransformed.Type = Enums.BloodType.A;
            else if (record.type == "B")
                recordTransformed.Type = Enums.BloodType.B;
            else if (record.type == "O")
                recordTransformed.Type = Enums.BloodType.O;
            else if (record.type == "AB")
                recordTransformed.Type = Enums.BloodType.AB;

            return recordTransformed;
        }
        
        public static BloodRequest CreateBloodRequestDTOToObject(CreateBloodRequestDTO newBloodRequest)
        {
           //BloodRequest bloodRequestTransformed= new BloodRequest();

 //           bloodRequestTransformed.Id = newBloodRequest.id;
   //         bloodRequestTransformed.DoctorId = "DOC1";          
     //       bloodRequestTransformed.Reason = newBloodRequest.reason;          
       //     bloodRequestTransformed.Due =Convert.ToDateTime(newBloodRequest.due);
            BloodType type = Enums.BloodType.A;
            if (newBloodRequest.type == "A")           
                type = Enums.BloodType.A;           
            else if (newBloodRequest.type == "B")
                type = Enums.BloodType.B;
            else if (newBloodRequest.type == "O")
                type = Enums.BloodType.O;
            else if (newBloodRequest.type == "AB")
                type = Enums.BloodType.AB;

            return new BloodRequest(newBloodRequest.id, type, newBloodRequest.amount, newBloodRequest.reason, Convert.ToDateTime(newBloodRequest.due));

        }
    }
}
