using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.PatientAppointmentCancelation
{
    public class PatientAppointmentCancelationRepository : IPatientAppointmentCancelationRepository
    {
        private readonly HospitalDbContext _context;

        public PatientAppointmentCancelationRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public IEnumerable<PatientAppointmentCancelation> GetAll()
        {
            return _context.PatientAppointmentCancelations.ToList();
        }
        public void Create(PatientAppointmentCancelation patientAppointmentCancelation)
        {
            _context.PatientAppointmentCancelations.Add(patientAppointmentCancelation);
            _context.SaveChanges();
        }
    }
}
