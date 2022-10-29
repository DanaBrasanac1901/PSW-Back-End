using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
//using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Doctor.Doctor SetDoctorAppointment(Doctor.Doctor doc)
        {
            return _appointmentRepository.SetDoctorAppointment(doc);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(string id)
        {
            return _appointmentRepository.GetById(id);
        }

        private int IdNumber()
        {
            IEnumerable<Appointment> listToCount =  _appointmentRepository.GetAll();
            return listToCount.Count() + 1;
        }

        public List<String> GetAllDatesAndTimesForDoctor(string doctorId)
        {
            IEnumerable<Appointment> allApp = GetAll();
            List<Appointment> allAppList = allApp.ToList();
            List<String> dateAndTime = new List<String>();
            foreach (var app in allApp)
            {
                if(app.DoctorId == doctorId)
                {
                    dateAndTime.Add(app.Start.ToString());
                }
                else
                {
                    continue;
                }
            }
            return dateAndTime;
        }

        public Boolean IsAvailable(Appointment app)
        {
            List<String> dateAndTimeList = GetAllDatesAndTimesForDoctor(app.DoctorId);
            String dateAndTimeToCheck = app.Start.ToString();
            foreach (var dateAndTime in dateAndTimeList)
            {
                if(dateAndTime == dateAndTimeToCheck)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        //Provera da ga zakaze za buducnost
        //public Boolean CheckIfAppointmentIsSetInFuture(DateTime dateToCheck)
        //{
        //    DateTime currentDate = DateTime.Now;
        //    switch (currentDate)
        //    {
        //        case currentDate.Year < dateToCheck.Year:

        //        default:
        //            break;
        //    }
        //}

        public void Create(CreateAppointmentDTO appointmentDTO)
        {

            Appointment app = AppointmentAdapter.CreateAppointmentDTOToAppointment(appointmentDTO);
            app.Id = "APP" + IdNumber().ToString();
            Boolean checkFlag = IsAvailable(app);
            if(checkFlag == true)
            {
                Console.WriteLine("Zauzet termin");
            }
            else
            {
                _appointmentRepository.Create(app);
            }
        }

        public void Update(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment);
        }

        public IEnumerable<Appointment> GetAllByDoctor(string id)
        {
            return _appointmentRepository.GetAllByDoctor(id);
        }
    }
}
