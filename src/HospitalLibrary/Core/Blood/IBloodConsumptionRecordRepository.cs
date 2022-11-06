using System.Collections.Generic;

namespace HospitalLibrary.Core.Blood
{
    public interface IBloodConsuptionRecordRepository
    {
        IEnumerable<BloodConsumptionRecord> GetAll();
        BloodConsumptionRecord GetById(int id);
        void Create(BloodConsumptionRecord bloodConsumptionRecord);
        void Update(BloodConsumptionRecord bloodConsumptionRecord);
        void Delete(BloodConsumptionRecord bloodConsumptionRecord);
    }
}