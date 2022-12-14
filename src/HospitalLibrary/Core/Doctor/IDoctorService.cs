using HospitalLibrary.Core.Doctor.DTOS;
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
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        DoctorsShiftDTO GetDoctorsShiftById(string id);
        Boolean IsAvailable(string id, DateTime time);
        List<GetAppointmentsUrgentVacationDTO> GetAppointmentsUrgentVacation(GetDoctorsAppointmentsForUrgentVacationDTO parameter);
        List<DoctorToChangeUrgentVacationDTO> GetFreeDoctors(string startDate,string startTime);
        bool AreAvailableForConsilium(List<Doctor> neededDoctors, DateTimeRange consiliumInterval);
        List<Doctor> GetByIds(string doctorIds);
        List<Doctor> GetAvailableBySpecialty(int specialty, DateTimeRange consiliumInterval);
        List<Doctor> AvailableByEachSpecialty(string specialties, DateTimeRange consiliumInterval);
    }
}
