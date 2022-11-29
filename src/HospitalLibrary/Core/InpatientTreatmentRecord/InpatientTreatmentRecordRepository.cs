using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public class InpatientTreatmentRecordRepository : IInpatientTreatmentRecordRepository
    {
        private readonly HospitalDbContext _context;

        public InpatientTreatmentRecordRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<InpatientTreatmentRecord> GetAll()
        {
            return _context.InpatientTreatmentRecords.ToList();
        }

        public InpatientTreatmentRecord GetById(string id)
        {
            return _context.InpatientTreatmentRecords.Find(id);
        }

        public void Create(InpatientTreatmentRecord inpatientTreatmentRecord)
        {

            var local = _context.Set<InpatientTreatmentRecord>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(inpatientTreatmentRecord.Id));

            
            if (local != null)
            {
                
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.InpatientTreatmentRecords.Add(inpatientTreatmentRecord);
            _context.Entry(inpatientTreatmentRecord).State = EntityState.Modified;
            

            _context.SaveChanges();
        }

        public void Update(InpatientTreatmentRecord inpatientTreatmentRecord)
        {
            _context.Entry(inpatientTreatmentRecord).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(InpatientTreatmentRecord inpatientTreatmentRecord)
        {
            _context.InpatientTreatmentRecords.Remove(inpatientTreatmentRecord);
            _context.SaveChanges();
        }

        public IEnumerable<InpatientTreatmentRecord> GetAllWithStatusTrue()
        {
            IEnumerable<InpatientTreatmentRecord> records = GetAll();
            return records.Where(r => r.Status == true);
        }

        public IEnumerable<InpatientTreatmentRecord> GetAllByDoctor(string id)
        {
            List<InpatientTreatmentRecord> records = _context.InpatientTreatmentRecords.Where(record => record.DoctorID.Equals(id)).ToList();
            return records;
        }
    }
}
