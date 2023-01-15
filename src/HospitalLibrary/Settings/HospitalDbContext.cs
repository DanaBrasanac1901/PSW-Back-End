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
using HospitalLibrary.Core.Consiliums;
using HospitalLibrary.Core.Report;
using HospitalLibrary.Core.Report.Model;
using Npgsql;
using System.Collections.Generic;
using HospitalLibrary.Core.ApptSchedulingSession.Storage;
using HospitalLibrary.Core.Infrastructure;

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
        
        public DbSet<Consilium> Consiliums {get; set;}
        
        public DbSet<ConsiliumAppointment> ConsiliumAppointments { get; set; }
        
        public DbSet<Report> Reports { get; set; }
        
        public DbSet<DrugPrescription> DrugPrescriptions { get; set; }
        
        public DbSet<Symptom> Symptoms { get; set; }
        
        public DbSet<Drug> Drugs { get; set; }
        
        public DbSet<DrugList> DrugsList { get; set; }
        
        public DbSet<SymptomList> SymptomList { get; set;}
        
        public DbSet<HealthMeasurements> HealthMeasurements { get; set; }

        public DbSet<PatientHealthMeasurements> PatientHealthMeasurements { get; set; }
        public DbSet<DomainEvent> ReportCreationEvents { get; set; }
      


        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Specialty>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Allergy>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Gender>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<BloodType>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<AppointmentStatus>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Gender>();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid bank1Id = new Guid("2D4894B6-02E4-4288-A3D3-089489563190");
            Guid bank2Id = new Guid("55510651-D36E-444D-95FB-871E0902CD7E");
            Guid bank3Id = new Guid("A60460FE-0D33-478D-93B3-45D424079E66");


            BloodSupply supplyABank1 = new BloodSupply(1, BloodType.A, 54, bank1Id);
            BloodSupply supplyBBank1 = new BloodSupply(2, BloodType.B, 30, bank1Id);
            BloodSupply supplyABBank1 = new BloodSupply(3, BloodType.AB, 15, bank1Id);
            BloodSupply supply0Bank1 = new BloodSupply(4, BloodType.O, 10, bank1Id);
            BloodSupply supplyABank2 = new BloodSupply(5, BloodType.A, 23, bank2Id);
            BloodSupply supplyBBank2 = new BloodSupply(6, BloodType.B, 40, bank2Id);
            BloodSupply supply0Bank2 = new BloodSupply(10, BloodType.O, 40, bank2Id);
            BloodSupply supplyABank3 = new BloodSupply(7, BloodType.A, 24, bank3Id);
            BloodSupply supplyBBank3 = new BloodSupply(8, BloodType.B, 10, bank3Id);
            BloodSupply supplyABBank3 = new BloodSupply(9, BloodType.AB, 34, bank3Id);

            modelBuilder.Entity<BloodSupply>().HasData(
                supply0Bank1, supplyABank1, supplyABank2, supplyABank3, supplyABBank1,
                supplyABBank3, supplyBBank1, supplyBBank2, supplyBBank3, supply0Bank2
            );

            DrugList drug1 = new DrugList("aspirin", "Aspirin", "Galenika");
            DrugList drug2 = new DrugList("brufen", "Brufen", "Galenika");
            DrugList drug3 = new DrugList("panadol", "Panadol", "Hemofarm");
            DrugList drug4 = new DrugList("bensedin", "Bensedin", "Galenika");
            DrugList drug5 = new DrugList("bromazepam", "Bromazepam", "Hemofarm");
            DrugList drug6 = new DrugList("fervex", "Fervex", "Bayer");
            DrugList drug7 = new DrugList("prospan", "Prospan", "Bayer");
            DrugList drug8 = new DrugList("strepsils", "Strepsils", "Bayer");
            DrugList drug9 = new DrugList("rivotril", "Rivotril", "Galenika");
            DrugList drug10 = new DrugList("baktrim", "Baktrim", "Hemofarm");
            DrugList drug11 = new DrugList("gentamicin", "Gentamicin", "Galenika");


            modelBuilder.Entity<DrugList>().HasData(
            drug1,drug2,drug3,drug4, drug5, drug6, drug7, drug8, drug9, drug10, drug11
            );


            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Number = "1A", Floor = 1 },
                new Room() { Id = 2, Number = "1B", Floor = 1 },
                new Room() { Id = 3, Number = "1C", Floor = 1 },
                new Room() { Id = 4, Number = "2A", Floor = 2 },
                new Room() { Id = 5, Number = "2B", Floor = 2 },
                new Room() { Id = 6, Number = "2C", Floor = 2 },
                new Room() { Id = 7, Number = "3A", Floor = 3 },
                new Room() { Id = 8, Number = "3B", Floor = 3 },
                new Room() { Id = 9, Number = "3F", Floor = 3 },
                new Room() { Id = 999, Number = "Consilium Hall", Floor = 4 }
                );

            modelBuilder.Entity<Equipment>().HasData(
                  new Equipment()
                  {
                      Id = "1",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 1
                  }, 
                  new Equipment()
                  {
                      Id = "2",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 2
                  },
                  new Equipment()
                  {
                      Id = "3",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 1
                  },
                  new Equipment()
                  {
                      Id = "4",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 3
                  },
                  new Equipment()
                  {
                      Id = "5",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 3
                  },
                  new Equipment()
                  {
                      Id = "6",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 2
                  },
                  new Equipment()
                  {
                      Id = "7",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 2
                  },
                  new Equipment()
                  {
                      Id = "8",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 6
                  },
                  new Equipment()
                  {
                      Id = "9",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 6
                  },
                  new Equipment()
                  {
                      Id = "10",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 5
                  },
                  new Equipment()
                  {
                      Id = "11",
                      Type = EquipmentType.BED,
                      Quantity = 1,
                      RoomId = 5
                  }
            );

            modelBuilder.Entity<SymptomList>().HasData(
                new SymptomList()
                {
                    Id= "Headache",
                    Name = "Headache"
                },
                new SymptomList()
                {
                    Id = "High blood pressure",
                    Name = "High blood pressure"
                },
                new SymptomList()
                {
                    Id = "Vertigo",
                    Name = "Vertigo"
                },
                new SymptomList()
                {
                    Id = "Fatigue",
                    Name = "Fatigue"
                },
                new SymptomList()
                {
                    Id = "Fever",
                    Name = "Fever"
                },
                new SymptomList()
                {
                    Id = "Short breath",
                    Name = "Short breath"
                },
                new SymptomList()
                {
                    Id = "Chronic pain",
                    Name = "Chronic pain"
                },
                new SymptomList()
                {
                    Id = "Vomiting",
                    Name = "Vomiting"
                },
                new SymptomList()
                {
                    Id = "Cough",
                    Name = "Cough"
                }
                );

            modelBuilder.Entity<DomainEvent>()
                .HasDiscriminator<string>("event_type")
                .HasValue<NextButtonClicked>("next")
                .HasValue<BackButtonClicked>("back")
                .HasValue<ReportCreated>("created")
                .HasValue<ReportFinished>("finished");

            base.OnModelCreating(modelBuilder);
        }



    }
}