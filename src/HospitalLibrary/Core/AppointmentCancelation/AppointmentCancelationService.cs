using HospitalLibrary.Core.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.AppointmentCancelation
{
    public class AppointmentCancelationService : IAppointmentCancelationService
    {
        private readonly IAppointmentCancelationRepository _appointmentCancelationRepository;
        private readonly IPatientRepository _patientRepository;
        public AppointmentCancelationService(IAppointmentCancelationRepository appointmentCancelationRepository, IPatientRepository _patientRepository)
        {
            _appointmentCancelationRepository = appointmentCancelationRepository;
        }
        public IEnumerable<AppointmentCancelation> GetAll()
        {
            return new List<AppointmentCancelation>();
        }
        public AppointmentCancelation GetById(int id)
        {
            return _appointmentCancelationRepository.GetById(id);
        }
        public void Create(string patientId, DateTime time)
        {
            _appointmentCancelationRepository.Create(new AppointmentCancelation(patientId, time));
        }
        public IEnumerable<string> GetMaliciousPatients()
        {
            var maliciousPatients = new List<string>();
            var canceledAppointments = _appointmentCancelationRepository.GetAll();
            var patients = _patientRepository.GetAll();
            foreach (Patient.Patient p in patients)
            {
                var counter = 0;
                foreach(var c in canceledAppointments)
                {
                    int.TryParse(c.PatientId, out int result);
                    if (p.Id == result)
                    {
                        counter++;
                    }
                }
                if(counter >= 3)
                {
                    maliciousPatients.Add((p.Id).ToString());
                }
            }
            return maliciousPatients;
        }
    }
}
