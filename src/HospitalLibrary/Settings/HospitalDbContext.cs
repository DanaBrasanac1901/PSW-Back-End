using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Vacation;
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

        public DbSet<VacationRequest> VacationRequests { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VacationRequest>();
            //modelBuilder.Entity<VacationRequest>().HasData(
            //    new VacationRequest(1, new DateTime(2023,1,1), new DateTime(2023, 1, 14), "holidays", false, "DOC1"),
            //    new VacationRequest(2, new DateTime(2023, 1, 1), new DateTime(2023, 1, 14), "holidays", false, "DOC2"),
            //    new VacationRequest(3, new DateTime(2023, 1, 1), new DateTime(2023, 1, 14), "holidays", false, "DOC3")
            //     );
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VacationRequest>().HasData(
                new VacationRequest() {
                    Id = 1,
                    Start = new DateTime(2022, 12, 10),
                    End = new DateTime(2022, 12, 20),
                    Description = "im tired nigga",
                    Urgency = false,
                    DoctorId = "DOC1",
                    Status = VacationRequestStatus.WaitingForApproval,
                    RejectionReason = ""
                },
                new VacationRequest() {
                    Id = 2,
                    Start = new DateTime(2023, 2, 10),
                    End = new DateTime(2023, 2, 20),
                    Description = "certified nigga",
                    Urgency = true,
                    DoctorId = "DOC1",
                    Status = VacationRequestStatus.Disapproved,
                    RejectionReason = "aca lukas je narkoman"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}