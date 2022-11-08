﻿using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
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
        private readonly IEmailSendService _emailSend;
        private string _email;
        public AppointmentService(IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository, 
            IRoomRepository roomRepository, IEmailSendService emailSend)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _roomRepository = roomRepository;
            _emailSend = emailSend;
            UpdateFinishedAppointments();
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

        //private int IdNumber()
        //{
        //    IEnumerable<Appointment> listToCount =  _appointmentRepository.GetAll();
        //    return listToCount.Count() + 1;
        //}

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

        public Boolean IsAvailableDateOnly(DateTime date, string docId)
        {
            Doctor.Doctor doc = _doctorRepository.GetById(docId);
            ICollection<Appointment> allApp = doc.Appointments;
            List<Appointment> allAppList = allApp.ToList();

            foreach (var appToCheck in allAppList)
            {
                if (appToCheck.Start.ToString() == date.ToString())
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
            app.Id = DateTime.Now.ToString("yyMMddhhmmssffffff");
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

        public void Update(RescheduleAppointmentDTO appointmentDTO)
        {
            Appointment appointment = GetById(appointmentDTO.id);
            string timeParse = appointmentDTO.date + " " + appointmentDTO.time;
            DateTime newStartTime = Convert.ToDateTime(timeParse);
            appointment.Start = newStartTime;
            _appointmentRepository.Update(appointment);
        }

        public void Delete(string appId)
        {
            var appointment =GetById(appId);
            if (appointment.PatientId == "Pera Peric")
            {
                _email = "imeprezime0124@gmail.com";
            }
            else if (appointment.PatientId == "Sima Simic")
            {
                _email = "milos.adnadjevic@gmail.com";
            }
            else if (appointment.PatientId == "Djordje Djokic")
            {
                _email = "jales32331@harcity.com";
            }


            var message = new Message(new string[] { _email }, "Appointment cancelled", "Dear Sir/Madam, \n" +
                " Your appointment is cancelled because your doctor has emergency call.\n " +
                "Please go to our site to make new appointment or call our Call center on 0800/ 100 100. \n Sincerely, \n Your Hospital.");
            
            _emailSend.SendEmail(message);

            Appointment app = _appointmentRepository.GetById(appId);
            app.Status = AppointmentStatus.Cancelled;
            _appointmentRepository.Update(app);
        }


        public IEnumerable<ViewAllAppointmentsDTO> GetAllByDoctor(string id)
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
    }
}
