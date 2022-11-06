using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Blood
{
    public class BloodConsumptionRecordRepository : IBloodConsuptionRecordRepository
    {
        private readonly HospitalDbContext _context;

        public BloodConsumptionRecordRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodConsumptionRecord> GetAll()
        {
            return _context.BloodConsumptionRecords.ToList();
        }

        public BloodConsumptionRecord GetById(int id)
        {
            return _context.BloodConsumptionRecords.Find(id);
        }

        public void Create(BloodConsumptionRecord bloodConsumptionRecord)
        {
            _context.BloodConsumptionRecords.Add(bloodConsumptionRecord);
            _context.SaveChanges();
        }

        public void Update(BloodConsumptionRecord bloodConsumptionRecord)
        {
            _context.Entry(bloodConsumptionRecord).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(BloodConsumptionRecord bloodConsumptionRecord)
        {
            _context.BloodConsumptionRecords.Remove(bloodConsumptionRecord);
            _context.SaveChanges();
        }
    }
}
