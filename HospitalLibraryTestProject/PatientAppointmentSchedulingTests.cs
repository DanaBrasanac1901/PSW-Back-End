using HospitalLibrary.Core;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Patient;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class PatientAppointmentSchedulingTests
    {
        private Mock<IDoctorRepository> doctorRepo;
        private Mock<IAppointmentRepository> appointmentRepo;
        private AvailableAppointmentService appointmentService;

        private void Setting_doctor_repository()
        {
            var doctors = new List<Doctor>();
            doctorRepo = new Mock<IDoctorRepository>();

            doctors.Add(new Doctor { Id = 1, Name = "Ivan", Surname = "Nikolic", Email = "inik@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 13 , Specialty= Specialty.Cardiologist});
            doctors.Add(new Doctor { Id = 2, Name = "Milica", Surname = "Todorovic", Email = "mtodorovic@hotmail.com", RoomId = 2, StartWorkTime = 8, EndWorkTime = 13 });
            doctors.Add(new Doctor { Id = 3, Name = "Darko", Surname = "Mitic", Email = "darkomitic@live.com", RoomId = 3, StartWorkTime = 13, EndWorkTime = 20 });
            doctors.Add(new Doctor { Id = 4, Name = "Selena", Surname = "Mirkovic", Email = "selmirkovic@gmail.com", RoomId = 4, StartWorkTime = 13, EndWorkTime = 20 });

            this.doctorRepo.Setup(m => m.GetAll()).Returns(doctors);

        }

        private void Setting_appointment_repository()
        {
            var appointments = new List<Appointment>();
            appointmentRepo = new Mock<IAppointmentRepository>();

            appointments.Add(new Appointment { Id = "APP1", DoctorId = 1, Start = new DateTime(2022, 12, 15, 12, 0, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP2", DoctorId = 1, Start = new DateTime(2022, 12, 16, 12, 20, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP3", DoctorId = 1, Start = new DateTime(2022, 12, 17, 12, 40, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP4", DoctorId = 2, Start = new DateTime(2022, 12, 18, 12, 0, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP5", DoctorId = 2, Start = new DateTime(2022, 12, 19, 12, 20, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP6", DoctorId = 2, Start = new DateTime(2022, 12, 19, 12, 40, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP7", DoctorId = 2, Start = new DateTime(2022, 12, 19, 13, 20, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP8", DoctorId = 2, Start = new DateTime(2022, 12, 19, 13, 40, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP10", DoctorId = 2, Start = new DateTime(2022, 12, 19, 14, 20, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP9", DoctorId = 2, Start = new DateTime(2022, 12, 19, 14, 00, 0), PatientId = 1 });
            appointments.Add(new Appointment { Id = "APP11", DoctorId = 2, Start = new DateTime(2022, 12, 19, 14, 40, 0), PatientId = 1 });


            this.appointmentRepo.Setup(m => m.GetAll()).Returns(appointments);
        }

        private void Setting_appointment_service()
        {
            Setting_doctor_repository();
            Setting_appointment_repository();
            appointmentService = new AvailableAppointmentService(appointmentRepo.Object, doctorRepo.Object);
        }


        [Fact]
        public void Finds_ideal_appointments()
        {
            Setting_appointment_service();
            Doctor testDoctor = new Doctor { Id = 1, Name = "Ivan", Surname = "Nikolic", Email = "inik@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 13 };
            AppointmentPatientDTO dto = new AppointmentPatientDTO(new DateTimeRange(new DateTime(2022, 12, 28), new DateTime(2022, 12, 30)), testDoctor);
            var result = appointmentService.FindAppointmentsWithSuggestions(dto, "date");
            Assert.NotEmpty(result);
        }

        
        [Fact]
        public void Doctor_priority_gets_appointment(){
            Setting_appointment_service();
            Doctor testDoctor = new Doctor { Id = 1, Name = "Ivan", Surname = "Nikolic", Email = "inik@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 13 };
            AppointmentPatientDTO dto = new AppointmentPatientDTO(new DateTimeRange(new DateTime(2022, 12, 28), new DateTime(2022, 12, 30)), testDoctor);
            var result = appointmentService.AppointmentsWithDatePriority(new DateTimeRange(new DateTime(2022,12,28), new DateTime(2022,12,30)), Specialty.Cardiologist);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void No_available_doctors_by_specialty() {
            Setting_appointment_service();
            Doctor testDoctor = new Doctor { Id = 1, Name = "Ivan", Surname = "Nikolic", Email = "inik@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 13 };
            var result = appointmentService.GetDoctorsByDateAndSpecialty(new DateTime(2023, 2, 2), Specialty.Neurosurgeon).ToList();
            Assert.Empty(result);
        }



    }
}
