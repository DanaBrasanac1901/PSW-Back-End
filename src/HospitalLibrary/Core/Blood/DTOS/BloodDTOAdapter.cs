using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood.DTOS
{
    public class BloodDTOAdapter
    {
        public static BloodConsumptionRecord CreateConsmptionRecordDTOToObject(CreateConsmptionRecordDTO record)
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

    }
}
