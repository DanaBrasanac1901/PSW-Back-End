using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class PatientHealthMeasurementsRepository : IPatientHealthMeasurementsRepository
    {
        private readonly HospitalDbContext _context;
        public PatientHealthMeasurementsRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PatientHealthMeasurements> GetAll()
        {
            return _context.PatientHealthMeasurements.ToList();
        }
        public PatientHealthMeasurements GetById(int id)
        {
            return _context.PatientHealthMeasurements.Find(id);
        }
        public void Create(PatientHealthMeasurements patientHealthMeasurements)
        {
            _context.PatientHealthMeasurements.Add(patientHealthMeasurements);
            _context.SaveChanges();
        }
        public void Update(PatientHealthMeasurements patientHealthMeasurements)
        {
            _context.Entry(patientHealthMeasurements).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public void Delete(PatientHealthMeasurements patientHealthMeasurements)
        {
            _context.PatientHealthMeasurements.Remove(patientHealthMeasurements);
            _context.SaveChanges();
        }
    }
}
