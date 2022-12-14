using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.PatientAppointmentCancelation
{
    public class PatientAppointmentCancelationService : IPatientAppointmentCancelationService
    {
        private readonly IPatientAppointmentCancelationRepository _patientAppointmentCancelationRepository;

        public PatientAppointmentCancelationService(IPatientAppointmentCancelationRepository repository)
        {
            _patientAppointmentCancelationRepository = repository;
        }
        public IEnumerable<PatientAppointmentCancelation> GetAll()
        {
            return _patientAppointmentCancelationRepository.GetAll();
        }
        public void Create(string patientId)
        {
            PatientAppointmentCancelation appCancel = new PatientAppointmentCancelation(patientId, DateTime.Now);
            _patientAppointmentCancelationRepository.Create(appCancel);
        }
    }
}
