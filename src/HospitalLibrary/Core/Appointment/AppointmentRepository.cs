using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Doctor.Doctor SetDoctorAppointment(Doctor.Doctor doc) {
            return _context.Doctors.FirstOrDefault(r => r.Id == doc.Id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetById(string id)
        {
            return _context.Appointments.Find(id);
        }

        public void Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllByDoctor(string id)
        {
            List<Appointment> appointments = _context.Appointments.Where(appointment => appointment.DoctorId.Equals(id) 
                                                                            && appointment.Status!=AppointmentStatus.Cancelled).ToList();
            return appointments;
        }

        public IEnumerable<Appointment> GetAllByPatient(string id)
        {
            List<Appointment> appointments = _context.Appointments.Where(appointment => appointment.PatientId.Equals(id)
                                                                            ).ToList();
            return appointments;
        }
    }
}
