using HospitalLibrary.Core.Consiliums.DTO;
using HospitalLibrary.Core;
using HospitalLibrary.Core.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public class ConsiliumService : IConsiliumService
    {
        private readonly IConsiliumRepository _consiliumRepository;
        private readonly Doctor.IDoctorService _doctorService;
        private readonly IRoomService _roomService;


        public ConsiliumService(IConsiliumRepository consiliumRepository, Doctor.DoctorService doctorService, Room.RoomService roomService)
        {
            _consiliumRepository = consiliumRepository;
            _doctorService = doctorService;
            _roomService = roomService;
        }

        public IEnumerable<Consilium> GetAll()
        {
            
            return _consiliumRepository.GetAll();
        }


        public Consilium Create(CreateConsiliumDoctorsDTO consiliumDto)
        {
            

           // _consiliumRepository.Create(consilium);

            return new Consilium();
        }


        public void Update(Consilium consilium)
        {
            _consiliumRepository.Update(consilium);
        }

        public List<DateTime> GetPotentialAppointmentTimes(ConsiliumAppointmentInfoDTO consiliumAppointmentInfo)
        {
            List<Doctor.Doctor> neededDoctors = new List<Doctor.Doctor>((IEnumerable<Doctor.Doctor>)_doctorService.GetByIds(consiliumAppointmentInfo.DoctorIds));
            
            int start_time = GetStartTime(neededDoctors);
            int end_time = GetEndTime(neededDoctors);

            List<DateTime> potentialConsiliumTimes = new List<DateTime>();


            //ovo ce se brisati, treba dto da se sredi



            for (DateTime day = consiliumAppointmentInfo.Start; day <= consiliumAppointmentInfo.End; day = day.AddDays(1))
            {
                DateTime start = new DateTime(day.Year, day.Month, day.Day, start_time, 0, 0);
                DateTime end = new DateTime(day.Year, day.Month, day.Day, end_time, 0, 0);

                TimeSpan duration = new TimeSpan(0, consiliumAppointmentInfo.Duration, 0);

                end = end.Subtract(duration);

                while (start <= end)
                {
                    DateTime currentEnd = start.AddMinutes(consiliumAppointmentInfo.Duration);
                    DateTimeRange potentialTime = new DateTimeRange(start, currentEnd);

                    if (_doctorService.AreAvailableForConsilium(consiliumAppointmentInfo.DoctorIds, potentialTime))
                        potentialConsiliumTimes.Add(start);

                    start = start.AddMinutes(consiliumAppointmentInfo.Duration);
                }
            }

            return potentialConsiliumTimes;
        }

        private int GetStartTime(List<Doctor.Doctor> doctors)
        {
            int maxStartTime = -1;
            foreach(Doctor.Doctor doctor in doctors)
            {
                if (doctor.StartWorkTime > maxStartTime)
                    maxStartTime = doctor.StartWorkTime;
            }

            return maxStartTime;
        }

        private int GetEndTime(List<Doctor.Doctor> doctors)
        {
            int minEndTime = 100;
            foreach (Doctor.Doctor doctor in doctors)
            {
                if (doctor.EndWorkTime < minEndTime)
                    minEndTime = doctor.EndWorkTime;
            }

            return minEndTime;
        }

    }
}
