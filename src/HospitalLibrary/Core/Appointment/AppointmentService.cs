using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Room;
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
        private readonly IDoctorRepository _doctorRepository;
        private readonly IRoomRepository _roomRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository, 
            IRoomRepository roomRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _roomRepository = roomRepository;
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

        public Boolean IsAvailable(Appointment app)
        {
            Doctor.Doctor doc = app.Doctor;
            ICollection<Appointment> allApp = app.Doctor.Appointments;
            List<Appointment> allAppList = allApp.ToList();

            foreach (var appToCheck in allAppList)
            {
                if(appToCheck.Start.ToString() == app.Start.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean CheckIfAppointmentIsSetInFuture(DateTime dateToCheck)
        {
            DateTime dateTimeNow = DateTime.Now;
            if (dateTimeNow.Year > dateToCheck.Year)
            {
                return true;
            }
            else if (dateTimeNow.Month > dateToCheck.Month && dateTimeNow.Year >= dateToCheck.Year)
            {
                return true;
            }
            else if (dateTimeNow.Day >= dateToCheck.Day && dateTimeNow.Month >= dateToCheck.Month && dateTimeNow.Year >= dateToCheck.Year) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Create(CreateAppointmentDTO appointmentDTO)
        {
            Appointment app = AppointmentAdapter.CreateAppointmentDTOToAppointment(appointmentDTO);
            app.Doctor = _doctorRepository.GetById(appointmentDTO.doctorId);
            app.Id = "APP" + IdNumber().ToString();
            Boolean checkFlag = IsAvailable(app);
            Boolean dateFlag = CheckIfAppointmentIsSetInFuture(app.Start);
            if(checkFlag == true)
            {
                Console.WriteLine("Zauzet termin");
                return "";
            }
            else if(dateFlag == true)
            {
                Console.WriteLine("Termine zakazivati za buducnost");
                return "";
            }
            else
            {
                _appointmentRepository.Create(app);
                return app.Id;
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
