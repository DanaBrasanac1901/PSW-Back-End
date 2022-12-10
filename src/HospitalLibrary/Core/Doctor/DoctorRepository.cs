using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Doctor
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext _context;

        

        public DoctorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetById(string id)
        {
            return _context.Doctors.Find(id);
        }

        public void Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public List<Doctor> GetByIds(string doctorIds)
        {
            List<Doctor> doctors = new List<Doctor>();
            string[] doctorIdsSplit = doctorIds.Split(",");
            foreach (string id in doctorIdsSplit)
                doctors.Add(GetById(id));

            return doctors;
        }

        public List<Doctor> GetBySpecialty(int specialty)
        {
            return _context.Doctors.Where(doctor => doctor.Specialty == specialty).ToList();
        }
    }
}
