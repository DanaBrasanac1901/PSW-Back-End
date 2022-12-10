using HospitalLibrary.Core.Doctor.DTOS;
using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(string id);
        List<Doctor> GetBySpecialty(string specialty);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        DoctorsShiftDTO GetDoctorsShiftById(string id);
        Boolean IsAvailable(string id, DateTime time);
        //List<Doctor> GetAllDoctorsForRescheduleForUrgentVacation(Appointment.Appointment appointment);
        List<GetAppointmentsUrgentVacationDTO> GetAppointmentsUrgentVacation(GetDoctorsAppointmentsForUrgentVacationDTO parameter);
        List<DoctorToChangeUrgentVacationDTO> GetFreeDoctors(string startDate,string startTime);

    }
}
