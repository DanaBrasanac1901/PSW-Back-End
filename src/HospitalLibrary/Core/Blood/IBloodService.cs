using HospitalLibrary.Core.Blood.DTOS;
using HospitalLibrary.Core.Doctor.DTOS;
using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood
{
    public interface IBloodService
    {        
       
        Guid CreateBloodConsumptionRecord(BloodConsumptionRecord record);
        void CreateBloodRequest(CreateBloodRequestDTO bloodRequest);
        int GenerateId(int type);
        BloodConsumptionRecord GetById(int id);
    }
}
