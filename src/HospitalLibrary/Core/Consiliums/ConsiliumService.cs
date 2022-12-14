using HospitalLibrary.Core.Consiliums.DTO;
using HospitalLibrary.Core.Room;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Consiliums
{
    public class ConsiliumService : IConsiliumService
    {
        private readonly IConsiliumRepository _consiliumRepository;
        private readonly Doctor.IDoctorService _doctorService;
        private readonly IRoomService _roomService;


        public ConsiliumService(IConsiliumRepository consiliumRepository, Doctor.IDoctorService doctorService, Room.IRoomService roomService)
        {
            _consiliumRepository = consiliumRepository;
            _doctorService = doctorService;
            _roomService = roomService;
        }

        public IEnumerable<ShowConsiliumDTO> GetAll()
        {
            List<Consilium> consiliums = _consiliumRepository.GetAll().ToList();
            List<ShowConsiliumDTO> consiliumDTOs = new List<ShowConsiliumDTO>();

            foreach(Consilium consilium in consiliums)
            {
                consiliumDTOs.Add(new ShowConsiliumDTO(consilium));
            }

            return consiliumDTOs;
        }


        public Consilium Create(PotentialAppointmentsDTO consiliumDto)
        {
            Consilium consilium = consiliumDto.ConvertToConsilium();

            consilium = _consiliumRepository.Create(consilium);

            return consilium;
        }

        public void Update(Consilium consilium)
        {
            _consiliumRepository.Update(consilium);
        }

        public List<PotentialAppointmentsDTO> GetPotentialAppointmentTimesForDoctors(ConsiliumRequestDTO consiliumAppointmentInfo)
        {
            List<Doctor.Doctor> neededDoctors = new List<Doctor.Doctor>((IEnumerable<Doctor.Doctor>)_doctorService.GetByIds(consiliumAppointmentInfo.DoctorIds));
            
            int start_time = GetStartTime(neededDoctors);
            int end_time = GetEndTime(neededDoctors);

            List<PotentialAppointmentsDTO> potentialConsiliumTimes = new List<PotentialAppointmentsDTO>();

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
                    
                    if (_doctorService.AreAvailableForConsilium(neededDoctors, potentialTime) && ConsiliumRoomAvailable(potentialTime))
                    {
                        PotentialAppointmentsDTO appointment = new PotentialAppointmentsDTO(consiliumAppointmentInfo.Topic, start, currentEnd, consiliumAppointmentInfo.Duration, neededDoctors, "");
                        potentialConsiliumTimes.Add(appointment);
                    }
                    start = start.AddMinutes(consiliumAppointmentInfo.Duration);
                }
            }

            return potentialConsiliumTimes;
        }

        public List<PotentialAppointmentsDTO> GetPotentialAppointmentTimesForSpecialties(ConsiliumRequestDTO consiliumAppointmentInfo)
        {
            int numOfDoctors = -1;
            List<PotentialAppointmentsDTO> potentialTimes = new List<PotentialAppointmentsDTO>();

            for (DateTime day = consiliumAppointmentInfo.Start; day <= consiliumAppointmentInfo.End; day = day.AddDays(1))
            {
                DateTime start = new DateTime(day.Year, day.Month, day.Day, 8, 0, 0);
                DateTime end = new DateTime(day.Year, day.Month, day.Day, 22, 0, 0);

                TimeSpan duration = new TimeSpan(0, consiliumAppointmentInfo.Duration, 0);

                end = end.Subtract(duration);

                while (start <= end)
                {
                    DateTime currentEnd = start.AddMinutes(consiliumAppointmentInfo.Duration);
                    DateTimeRange potentialTime = new DateTimeRange(start, currentEnd);

                    List<Doctor.Doctor> availableDoctors = _doctorService.AvailableByEachSpecialty(consiliumAppointmentInfo.Specialties, potentialTime);

                    start = start.AddMinutes(consiliumAppointmentInfo.Duration);

                    if (availableDoctors == null || !ConsiliumRoomAvailable(potentialTime))
                        continue;
                    if (availableDoctors.Count > numOfDoctors)
                    {
                        numOfDoctors = availableDoctors.Count;
                        potentialTimes = new List<PotentialAppointmentsDTO>();
                    }
                    PotentialAppointmentsDTO appointment = new PotentialAppointmentsDTO(consiliumAppointmentInfo.Topic, start, currentEnd, consiliumAppointmentInfo.Duration, availableDoctors, consiliumAppointmentInfo.Specialties);
                    potentialTimes.Add(appointment);                
                }
            }
            return potentialTimes;
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

        private bool ConsiliumRoomAvailable(DateTimeRange potentialTime)
        {
            foreach(Consilium consilium in _consiliumRepository.GetAll())
            {
                DateTimeRange consiliumTime = new DateTimeRange(consilium.Start, consilium.Start.AddMinutes(consilium.Duration));
                if (consiliumTime.OverlapsWith(potentialTime))
                    return false;
            }

            return true;
        }
    }
}
