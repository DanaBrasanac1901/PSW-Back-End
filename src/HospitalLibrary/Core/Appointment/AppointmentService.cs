using Castle.Core.Internal;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.Room;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        private readonly IAppointmentRepository _appointmentRepositoryMock;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IEmailSendService _emailSend;
        private string _email;

        public AppointmentService(IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository,
            IPatientRepository patientRepository, IRoomRepository roomRepository, IEmailSendService emailSend)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _roomRepository = roomRepository;
            _emailSend = emailSend;
            UpdateFinishedAppointments();
        }

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
        /// 
        /// implementirati -> gledati radno vreme vacation  i appointments da lli postoje
        public Boolean IsAvailable(Appointment app)
        {
            Doctor.Doctor doc = app.Doctor;
            if (app.Doctor.Appointments == null)
            {
                return true;
            }
            ICollection<Appointment> allApp = app.Doctor.Appointments;
            //List<Appointment> allAppList = allApp.ToList();
            
            foreach (var appToCheck in allApp.ToList())
            {
                if(appToCheck.Start.ToString() == app.Start.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public static Boolean CheckIfAppointmentIsSetInFuture(DateTime dateToCheck)
        {
            DateTime dateTimeNow = DateTime.Now;
            if (dateTimeNow.Year > dateToCheck.Year)
            {
                return false;
            }
            else if (dateTimeNow.Month > dateToCheck.Month && dateTimeNow.Year >= dateToCheck.Year)
            {
                return false;
            }
            else if (dateTimeNow.Day >= dateToCheck.Day && dateTimeNow.Month >= dateToCheck.Month && dateTimeNow.Year >= dateToCheck.Year) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Create(CreateAppointmentDTO appointmentDTO)
        {
            Appointment app = AppointmentAdapter.CreateAppointmentDTOToAppointment(appointmentDTO);
            app.Doctor = _doctorRepository.GetById(appointmentDTO.doctorId);
            app.Id = DateTime.Now.ToString("yyMMddhhmmssffffff");
            if(IsAvailable(app) == false)
            {
                Console.WriteLine("Zauzet termin");
                return "";
            }
            else if(CheckIfAppointmentIsSetInFuture(app.Start) == false)
            {
                Console.WriteLine("Termine zakazivati za buducnost");
                return "";
            }
            else
            {
                _appointmentRepository.Create(app);
                return "Passed";
            }
        }

        public void Update(RescheduleAppointmentDTO appointmentDTO)
        {
            Appointment appointment = GetById(appointmentDTO.id);
            Appointment appToSend = appointment;
            DateTime startTime = DateTime.Parse(appointmentDTO.date + " " + appointmentDTO.time);
            if (IsAvailableAppointment(startTime, appointment.DoctorId) == true && CheckIfAppointmentIsSetInFuture(startTime) == true)
            {
                appToSend.Start = startTime;
                _appointmentRepository.Update(appToSend);
            }
        }

        public Boolean IsAvailableAppointment(DateTime start, int docId)
        {
            Doctor.Doctor doc = _doctorRepository.GetById(docId);
            if (doc.Appointments == null)
            {
                return true;
            }
            ICollection<Appointment> allApp = doc.Appointments;
            //List<Appointment> allAppList = allApp.ToList();

            foreach (var appToCheck in allApp.ToList())
            {
                if (appToCheck.Start == start)
                {
                    return false;
                }
            }
            return true;
        }

        private string GetEmail(int patientId)
        {
            //if (patientId == "Pera Peric")
            //{
            //    return "imeprezime0124@gmail.com";
            //}
            //else if (patientId == "Sima Simic")
            //{
            //    return "milos.adnadjevic@gmail.com";
            //}
            //else if (patientId == "Djordje Djokic")
            //{
            //    return "jales32331@harcity.com";
            //}else
            //{
            //    return "";
            //}

            Patient.Patient patient = _patientRepository.GetById(patientId);
            string email = patient.Email;
            return email;

        }

        public void Delete(string appId)
        {
            var appointment =GetById(appId);
            _email = GetEmail(appointment.PatientId);
            var message = new Message(new string[] { _email }, "Appointment cancelled", "Dear Sir/Madam, \n" +
                " Your appointment is cancelled because your doctor has emergency call.\n " +
                "Please go to our site to make new appointment or call our Call center on 0800/ 100 100. \n Sincerely, \n Your Hospital.");
            _emailSend.SendEmail(message);
            Appointment app = _appointmentRepository.GetById(appId);
            app.Status = AppointmentStatus.Cancelled;
            _appointmentRepository.Update(app);
        }


        public IEnumerable<ViewAllAppointmentsDTO> GetAllByDoctor(int id)
        {
            IEnumerable<Appointment> doctorsApointments = _appointmentRepository.GetAllByDoctor(id);
            List<ViewAllAppointmentsDTO> appointmentsDTOs = new List<ViewAllAppointmentsDTO>();
            foreach(Appointment a in doctorsApointments)
                appointmentsDTOs.Add(AppointmentAdapter.AppointmentToViewAllAppointmentsDTO(a));

            return appointmentsDTOs;
        }

        public void UpdateFinishedAppointments()
        {
            List<Appointment> appointments = (List<Appointment>)_appointmentRepository.GetAll();

            TimeSpan difference;
            DateTime currentTime = DateTime.Now;

            foreach (Appointment appointment in appointments)
            {
                difference = currentTime.Subtract(appointment.Start);
                if (difference.TotalMinutes > 20)
                {
                    appointment.Status = AppointmentStatus.Finished;
                    _appointmentRepository.Update(appointment);
                }
            }
        }

        public RescheduleAppointmentDTO GetAppoitnemtnToReschedule(string id)
        {
            Appointment app = _appointmentRepository.GetById(id);
            RescheduleAppointmentDTO dto = AppointmentAdapter.AppointmentToRescheduleAppointmentDTO(app);
            return dto;
        }

       
        public Boolean CheckIfAppointmentExistsForDoctor(int doctorId,DateTime start)
        {
            
            foreach (var app in _appointmentRepository.GetAll())
            {
                if(app.DoctorId == doctorId && app.Start == start)
                {
                    return false;
                }
            }
            return true;
        }

        public void ChangeDoctorForAppointment(int doctorId, string appointmentId)
        {
            var appointment = _appointmentRepository.GetById(appointmentId);
            
            if(CheckIfAppointmentExistsForDoctor(doctorId,appointment.Start) == true)
            {
                appointment.DoctorId = doctorId;
                _appointmentRepository.Update(appointment);
            }
                
        }

        public AppointmentForReportDTO GetAppointmentForReport(string appId)
        {
            return AppointmentAdapter.AppointmentToAppointmentForReportDTO(_appointmentRepository.GetById(appId));
        }
        public IEnumerable<Patient.Patient> GetDoctorsPatients(int id)
        {
            var apps = _appointmentRepository.GetAllByDoctor(id);
            List<Patient.Patient> patients = new();
            foreach (var appointment in apps)
            {
                var patient = _patientRepository.GetById(appointment.PatientId);
                if (!patients.Contains(patient))
                {
                    patients.Add(patient);
                }
            }
            return patients;
        }
    }
}