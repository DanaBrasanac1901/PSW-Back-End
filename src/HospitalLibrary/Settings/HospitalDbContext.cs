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
using HospitalLibrary.Core.InpatientTreatmentRecord;

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
        
        public DbSet<InpatientTreatmentRecord> InpatientTreatmentRecords { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InpatientTreatmentRecord>().HasData(
                new InpatientTreatmentRecord()
                {
                    Id = "1",
                    DoctorID = "1",
                    PatientID = "1",
                    RoomID = "1",
                    BedID = "1",
                    AdmissionDate = new DateTime(2022, 12, 25),
                    Status = true,
                    Therapy = "nista",
                    AdmissionReason = "bolesnik",
                    DischargeReason = "",
                    DischargeDate = new DateTime(22,12,29)

                }
           
            ) ;

            modelBuilder.Entity<Equipment>().HasData(
                  new Equipment()
                  {
                      Id = "1",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 1

                  }
            );
           base.OnModelCreating(modelBuilder);
        }

    }
}