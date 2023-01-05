using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalLibrary.Core.User;
using Npgsql;
using System.Collections.Generic;
using HospitalLibrary.Core.ApptSchedulingSession.Storage;

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

        public DbSet<EventStream> EventStreams { get; set; }    
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<InpatientTreatmentRecord> InpatientTreatmentRecords { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<User> Users { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Specialty>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Gender>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<BloodType>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<AppointmentStatus>();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Specialty>();
            modelBuilder.HasPostgresEnum<Gender>();
            modelBuilder.HasPostgresEnum<BloodType>();
            modelBuilder.HasPostgresEnum<AppointmentStatus>();

            Guid bank1Id = new Guid("2D4894B6-02E4-4288-A3D3-089489563190");
            Guid bank2Id = new Guid("55510651-D36E-444D-95FB-871E0902CD7E");
            Guid bank3Id = new Guid("A60460FE-0D33-478D-93B3-45D424079E66");

            BloodSupply supplyABank1 = new BloodSupply(1, BloodType.A, 54, bank1Id);
            BloodSupply supplyBBank1 = new BloodSupply(2, BloodType.B, 30, bank1Id);
            BloodSupply supplyABBank1 = new BloodSupply(3, BloodType.AB, 15, bank1Id);
            BloodSupply supply0Bank1 = new BloodSupply(4, BloodType.O, 10, bank1Id);
            BloodSupply supplyABank2 = new BloodSupply(5, BloodType.A, 23, bank2Id);
            BloodSupply supplyBBank2 = new BloodSupply(6, BloodType.B, 40, bank2Id);
            BloodSupply supplyABank3 = new BloodSupply(7, BloodType.A, 24, bank3Id);
            BloodSupply supplyBBank3 = new BloodSupply(8, BloodType.B, 10, bank3Id);
            BloodSupply supplyABBank3 = new BloodSupply(9, BloodType.AB, 34, bank3Id);

            modelBuilder.Entity<BloodSupply>().HasData(
                supply0Bank1, supplyABank1, supplyABank2, supplyABank3, supplyABBank1,
                supplyABBank3, supplyBBank1, supplyBBank2, supplyBBank3
            );


            BloodConsumptionRecord bloodConsumptionRecord1 = new BloodConsumptionRecord(1, 2, BloodType.A, "needed for surgery", new DateTime(2022, 11, 22), "DOC1", bank1Id);


            modelBuilder.Entity<BloodConsumptionRecord>().HasData(
                bloodConsumptionRecord1
                );


            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Number = "1A", Floor = 1 }
                );
            User user1 = new User(1, 1, "Milica", "Peric", "manager", "AJMjUEYXE/EtKJlD2NfDblnM15ik0Wo547IgBuUFWyJtWRhj5PSBO/ttok4DT679oA==", "MANAGER", true);
            User user2 = new User(2, 1, "Filip", "Marinkovic", "doctor", "AKTyL6i1roIESl/br0aDrci1H15gFj0Wwede2GYJi0csDSUhrydNioQui0K3gfkJcA==", "DOCTOR", true);
            User user3 = new User(3, 1, "Jelena", "Novakovic", "patient", "AEssL8tRDqEPwGzxIeyAU1F/kuq1w4klNScLgIOmwe/N+j4e24+2DR8o31HhYtWziw==", "PATIENT", true);
            modelBuilder.Entity<User>().HasData(user1, user2, user3);

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
                    DischargeDate = new DateTime(22, 12, 29)

                }

            );

            modelBuilder.Entity<Equipment>().HasData(
                  new Equipment()
                  {
                      Id = "1",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 1

                  }
            );

            modelBuilder.Entity<Patient>().Property(p => p.Address).HasColumnType("jsonb");
            Patient patient1 = new(1, "Jelena", "Novakovic", "Futoska,62,Novi Sad", "patient", Gender.FEMALE, 31, BloodType.A, null, null);
            modelBuilder.Entity<Patient>().HasData(patient1);


            base.OnModelCreating(modelBuilder);
        }



    }
}