using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Appointment> Appointments {get; set;}

        public DbSet<Doctor> Doctors { get; set; }

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
                Room = room1,
                StartWorkTime = 8,
                EndWorkTime = 15,
                Appointments = null
            };
            Doctor doctor2 = new Doctor()
            {
                Id = "DOC2",
                Name = "Pera",
                Surname = "Peric",
                Email = "peraperic024@gmail.com",
                Room = room2,
                StartWorkTime = 8,
                EndWorkTime = 15,
                Appointments = null
            };
            Doctor doctor3 = new Doctor()
            {
                Id = "DOC3",
                Name = "Djole",
                Surname = "Djokic",
                Email = "djole1312@gmail.com",
                Room = room3,
                StartWorkTime = 8,
                EndWorkTime = 15,
                Appointments = null
            };

            modelBuilder.Entity<Doctor>().HasData(
                doctor1, doctor2, doctor3
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = "APP1",
                    Doctor = doctor1,
                    PatientId = "PAT1",
                    Start = new DateTime(2022, 10, 25, 12, 20, 0)

                },
                new Appointment
                {
                    Id = "APP2",
                    Doctor = doctor2,
                    PatientId = "PAT2",
                    Start = new DateTime(2022, 10, 25, 12, 20, 0)

                },
                new Appointment
                {
                    Id = "APP3",
                    Doctor = doctor3,
                    PatientId = "PAT3",
                    Start = new DateTime(2022, 10, 25, 12, 20, 0)
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
