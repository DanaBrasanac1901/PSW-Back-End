using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Patient;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<BloodSupply> HospitalBlood { get; set; }

        public DbSet<BloodConsumptionRecord> BloodConsumptionRecords { get; set; }

        public DbSet<BloodRequest> BloodRequests { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            Feedback feedback1 = new Feedback() {ID=1, PatientId = 1, Text="neki komentar", VisibleToPublic=true, Approved = false, Date = new DateTime(2022,8,27,8,15,0)};
            Feedback feedback2 = new Feedback() {ID=2, PatientId = 2, Text = "neki drugi komentar", VisibleToPublic = true, Approved = false, Date = new DateTime(2022,9,13,14,53,0)};
            Feedback feedback3 = new Feedback(new Feedback.FeedbackBuilder().PatientID(3).Text("neki treci komentar").VisibleToPublic(true).Approved(false).Date(new DateTime(2022,10,10,11,22,0)).ID(3).Anonymous(false));
            modelBuilder.Entity<Feedback>().HasData(
               feedback1,feedback2,feedback3
            );

            modelBuilder.Entity<BloodSupply>().HasData(
                new BloodSupply()
                {
                    Id = 1,
                    Type = BloodType.A,
                    Amount = 150
                    
                },
                new BloodSupply()
                {
                    Id = 2,
                    Type = BloodType.B,
                    Amount = 130
                    
                },
                new BloodSupply()
                {
                    Id = 3,
                    Type = BloodType.AB,
                    Amount = 100
                },
                new BloodSupply()
                {
                    Id = 4,
                    Type = BloodType.O,
                    Amount = 110 
                }
            );

            modelBuilder.Entity<BloodConsumptionRecord>().HasData(
            new BloodConsumptionRecord()
            {
                Id = 1,
                Amount = 10,
                Type = BloodType.A,
                CreatedAt = DateTime.Now,
                Reason = "need for surgery",
                DoctorId = "DOC1"
            },
            new BloodConsumptionRecord()
            {
                Id = 2,
                Amount = 20,
                Type = BloodType.B,
                CreatedAt = DateTime.Now,
                Reason = "need for patient treatment",
                DoctorId = "DOC2"
            },
            new BloodConsumptionRecord()
            {
                Id = 3,
                Amount = 15,
                Type = BloodType.AB,
                CreatedAt = DateTime.Now,
                Reason = "need for transfusion",
                DoctorId = "DOC1"
            }
            );

            modelBuilder.Entity<BloodRequest>().HasData(
            new BloodRequest()
            {
                Id = 1,
                DoctorId = "DOC1",
                Type = BloodType.A,
                Amount = 100,
                Reason = "need for patient treatment",
                Due = new DateTime(2022,11,15)
                
            },
            new BloodRequest()
            {
                Id = 2,
                DoctorId = "DOC2",
                Type = BloodType.B,
                Amount = 150,
                Reason = "need for patient treatment",
                Due = new DateTime(2022,11,20)
            },
            new BloodRequest()
            {
                Id = 3,
                DoctorId = "DOC1",
                Type = BloodType.AB,
                Amount = 150,
                Reason = "need for transfusion",
                Due = new DateTime(2022,11,25)
            }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}