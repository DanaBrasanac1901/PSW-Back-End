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
        Doctor GetById(int id);
        List<Doctor> GetBySpecialty(string specialty);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        DoctorsShiftDTO GetDoctorsShiftById(int id);
        Boolean IsAvailable(int id, DateTime time);
        List<GetAppointmentsUrgentVacationDTO> GetAppointmentsUrgentVacation(GetDoctorsAppointmentsForUrgentVacationDTO parameter);
        List<DoctorToChangeUrgentVacationDTO> GetFreeDoctors(string startDate,string startTime);


        List<Doctor> GetFreeSpecialtyDoctors(string date, int specialty);
        List<int> GetSpecialtyDoctors(int specialty);

        bool AreAvailableForConsilium(List<Doctor> neededDoctors, DateTimeRange consiliumInterval);
        IEnumerable<Doctor> GetByIds(string doctorIds);
        List<Doctor> GetAvailableBySpecialty(int specialty, DateTimeRange consiliumInterval);
        List<Doctor> AvailableByEachSpecialty(string specialties, DateTimeRange consiliumInterval);
    }
}
