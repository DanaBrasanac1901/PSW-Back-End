using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Appointment> Appointments {get; set;}

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Room room1 = new Room() { Id = 1, Number = "101A", Floor = 1 };
            Room room2 = new Room() { Id = 2, Number = "204", Floor = 2 };
            Room room3 = new Room() { Id = 3, Number = "305B", Floor = 3 };
            modelBuilder.Entity<Room>().HasData(
               room1, room2, room3
            );

            Doctor doctor1 = new Doctor()
            {
                Id = "DOC1",
                Name = "Ime",
                Surname = "Prezime",
                Email = "imeprezime024@gmail.com",
                RoomId = room1.Id,
                StartWorkTime = 8,
                EndWorkTime = 15,
                Appointments = new List<Appointment>()
            };
            Doctor doctor2 = new Doctor()
            {
                Id = "DOC2",
                Name = "Pera",
                Surname = "Peric",
                Email = "peraperic024@gmail.com",
                RoomId = room2.Id,
                StartWorkTime = 8,
                EndWorkTime = 15,
                Appointments = new List<Appointment>()
            };
            Doctor doctor3 = new Doctor()
            {
                Id = "DOC3",
                Name = "Djole",
                Surname = "Djokic",
                Email = "djole1312@gmail.com",
                RoomId = room3.Id,
                StartWorkTime = 8,
                EndWorkTime = 15,
                Appointments = new List<Appointment>()
            };

            modelBuilder.Entity<Doctor>().HasData(
                doctor1, doctor2, doctor3
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = "APP1",
                    DoctorId = doctor1.Id,
                    PatientId = "PAT1",
                    Start = new DateTime(2022, 10, 25, 12, 20, 0),
                    RoomId = room1.Id
                },
                new Appointment
                {
                    Id = "APP2",
                    DoctorId = doctor2.Id,
                    PatientId = "PAT2",
                    Start = new DateTime(2022, 10, 25, 12, 20, 0),
                    RoomId = room2.Id
                },
                new Appointment
                {
                    Id = "APP3",
                    DoctorId = doctor3.Id,
                    PatientId = "PAT3",
                    Start = new DateTime(2022, 10, 25, 12, 20, 0),
                    RoomId = room2.Id
                }
            );

            Feedback feedback1 = new Feedback() { PatientId = 1, Text="neki komentar", Visibility=true, Approved = false, Date = new DateTime(2022,8,27,8,15,0)};
            Feedback feedback2 = new Feedback() { PatientId = 2, Text = "neki drugi komentar", Visibility = true, Approved = false, Date = new DateTime(2022,9,13,14,53,0)};
            Feedback feedback3 = new Feedback() { PatientId = 3, Text = "neki treci komentar", Visibility = true, Approved = false, Date = new DateTime(2022,10,10,11,22,0)};
            modelBuilder.Entity<Feedback>().HasData(
               feedback1,feedback2,feedback3
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
