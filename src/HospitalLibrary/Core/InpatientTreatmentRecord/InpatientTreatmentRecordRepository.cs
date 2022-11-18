﻿using HospitalLibrary.Settings;
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
            _context.InpatientTreatmentRecords.Add(inpatientTreatmentRecord);
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
    }
}