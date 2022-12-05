﻿using HospitalLibrary.Core.Consiliums.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using HospitalLibrary.Core;
using HospitalLibrary.Core.Doctor;
using Moq;
using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.Consiliums;
using HospitalLibrary.Core.Appointment;

namespace HospitalLibraryTestProject
{
    public class ConsiliumCreationTests
    {
        [Fact]
        public void Has_available_appointments()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            RoomService roomService = new RoomService(CreateRoomRepository());
            ConsiliumService consiliumService = new ConsiliumService(CreateConsiliumRepository(), doctorService, roomService); 
            ConsiliumAppointmentInfoDTO consiliumAppointmentInfo = new ConsiliumAppointmentInfoDTO(new DateTimeRange(new DateTime(2022, 12, 14), new DateTime(2022, 12, 18)), 45, "DOC1,DOC2"); 

            List<DateTime> potentialConsiliumAppointments = consiliumService.GetPotentialAppointmentTimes(consiliumAppointmentInfo);

            Assert.NotEmpty(potentialConsiliumAppointments);
        }
        [Fact]
        public void Has_no_available_appointments()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            RoomService roomService = new RoomService(CreateRoomRepository());
            ConsiliumService consiliumService = new ConsiliumService(CreateConsiliumRepository(), doctorService, roomService);
            
            ConsiliumAppointmentInfoDTO consiliumAppointmentInfo = new ConsiliumAppointmentInfoDTO(new DateTimeRange(new DateTime(2022, 12, 15), new DateTime(2022, 12, 16)), 45, "DOC1,DOC2");

            List<DateTime> potentialConsiliumAppointments = consiliumService.GetPotentialAppointmentTimes(consiliumAppointmentInfo);

            Assert.Empty(potentialConsiliumAppointments);
        }

        [Fact]
        public void Doctors_available()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            DateTimeRange consiliumInterval = new DateTimeRange(new DateTime(2022, 12, 15, 15, 45, 0), new DateTime(2022, 12, 15, 15, 55, 0));

            bool available = doctorService.AreAvailableForConsilium("DOC1,DOC2", consiliumInterval);

            Assert.True(available);
        }

        [Fact]
        public void Doctors_not_available()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            DateTimeRange consiliumInterval = new DateTimeRange(new DateTime(2022, 12, 15, 14, 50, 0), new DateTime(2022, 12, 15, 15, 30, 0));


            bool available = doctorService.AreAvailableForConsilium("DOC1,DOC2", consiliumInterval);

            Assert.False(available);
        }

        private IDoctorRepository CreateDoctorRepository()
        {
            var stubRepo = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();

            List<Appointment> doctorAppointments = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP0", "DOC1", "PAT0", new DateTime(2022, 12, 15, 15, 20, 0), 0));
            
            Doctor doctor1 = new Doctor("DOC1", "Doktor", "Doktoric", "nekimail@gmail.com", 0, new Room(), 8, 16, doctorAppointments);
            doctors.Add(doctor1);


            doctorAppointments = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP1", "DOC2", "PAT0", new DateTime(2022, 12, 15, 16, 0, 0), 0));
            
            
            Doctor doctor2 = new Doctor("DOC2", "Doktorka", "Doktoricka", "nekimail@gmail.com", 0, new Room(), 8, 16, doctorAppointments);
            doctors.Add(doctor2);

            stubRepo.Setup(m => m.GetAll()).Returns(doctors);
            stubRepo.Setup(m => m.GetByIds("DOC1,DOC2")).Returns(doctors);

            return stubRepo.Object;
        }

        private IRoomRepository CreateRoomRepository()
        {
            var stubRepo = new Mock<IRoomRepository>();
            var rooms = new List<Room>();

            //create an instance of consilium room

            stubRepo.Setup(m => m.GetAll()).Returns(rooms);

            return stubRepo.Object;
        }

        private IConsiliumRepository CreateConsiliumRepository()
        {
            var stubRepo = new Mock<IConsiliumRepository>();

            return stubRepo.Object;
        }
    }
}