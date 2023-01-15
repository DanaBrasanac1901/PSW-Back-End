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
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Xml.Linq;

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
            NpgsqlConnection.GlobalTypeMapper.MapEnum<EquipmentType>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<VacationRequestStatus>();


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Specialty>();
            modelBuilder.HasPostgresEnum<Allergy>();
            modelBuilder.HasPostgresEnum<Gender>();
            modelBuilder.HasPostgresEnum<BloodType>();
            modelBuilder.HasPostgresEnum<AppointmentStatus>();
            modelBuilder.HasPostgresEnum<EquipmentType>();
            modelBuilder.HasPostgresEnum<VacationRequestStatus>();

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
            

            modelBuilder.Entity<User>().HasData(
                  new User()
                  {
                      Id = 1,
                      IdByRole = 1,
                      Name = "Milica",
                      Surname = "Peric",
                      Email = "manageremail@gmail.com",
                      Password = "AJMjUEYXE/EtKJlD2NfDblnM15ik0Wo547IgBuUFWyJtWRhj5PSBO/ttok4DT679oA==",
                      Role = "MANAGER",
                      Active = true,
                      Token = null
                  },
                  new User()
                  {
                      Id = 2,
                      IdByRole = 1,
                      Name = "Filip",
                      Surname = "Marinkovic",
                      Email = "doctorfilip@hotmail.com",
                      Password = "AKTyL6i1roIESl/br0aDrci1H15gFj0Wwede2GYJi0csDSUhrydNioQui0K3gfkJcA==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                  },
                  new User()
                  {
                      Id = 3,
                      IdByRole = 2,
                      Name = "Gorana",
                      Surname = "Miljkovic",
                      Email = "gorana.miljkovic@gmail.com",
                      Password = "AGEU6JzOVaDY+DYUWWiWOKbrpIHMwuW2fyh6CJai+D159dhE0IRmWjM3oQVlAS3hlw==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                   },
                  new User()
                  {
                      Id = 4,
                      IdByRole = 3,
                      Name = "Petar",
                      Surname = "Dobrosavljevic",
                      Email = "petar.dobrosavljevic@gmail.com",
                      Password = "AAQWjfiC3pkhMnwzKmJjhwytFO73mFNYklxj6/hTSj0aS3j3KxTe7TsmqVmXSy0fnQ==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                  },
                  new User()
                  {
                      Id = 5,
                      IdByRole = 4,
                      Name = "Stefan",
                      Surname = "Simic",
                      Email = "stefan.simic@gmail.com",
                      Password = "AJbKG1PpVed0VCFu358yyNfXy8RsWk6sB55ejeXQaFOV3nQxSImn6qsLGS6N5oQfqg==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                  },
                  new User()
                  {
                      Id = 6,
                      IdByRole = 5,
                      Name = "Bojana",
                      Surname = "Jelic",
                      Email = "bojana.jelic@gmail.com",
                      Password = "AEHe2m50J9F9RMJHmvuxZAQ9VFzCV7ebMjJFG/NND8GQM/C3tBut/fl1mhz0veof5Q==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                  },
                  new User()
                  {
                      Id = 7,
                      IdByRole = 6,
                      Name = "Katarina",
                      Surname = "Radic",
                      Email = "katarina.radic@gmail.com",
                      Password = "APxtdhzFubuhYnLITUwNYcwwt0ySvkTJ7C5qayocG3x5L9p3MbN3P0f27EYOCCInvw==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                  },
                  new User()
                  {
                      Id = 8,
                      IdByRole = 7,
                      Name = "Milica",
                      Surname = "Jezdic",
                      Email = "milica.jezdic@gmail.com",
                      Password = "ADCyG1fHX04K+wTwzJDPmb78k1YWMfTQqgeDZKorMbE46o0+zXEc2NF1SHjkEAiaWw==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                  },
                  new User()
                  {
                      Id = 9,
                      IdByRole = 8,
                      Name = "Zoran",
                      Surname = "Katic",
                      Email = "zoran.katic@gmail.com",
                      Password = "AA+E3CZi5TQ3+ciHGpGi7NFiE2GZDawBlSyBOK4IZd28ZB6oZWWOqY+gxY93xmI8kw==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                  },
                  new User()
                  {
                      Id = 10,
                      IdByRole = 9,
                      Name = "Bojan",
                      Surname = "Stanic",
                      Email = "bojan.stanic@gmail.com",
                      Password = "AL4E2lLskVtWAOnmsPLxHDP8hxJVqshvbL2F6uKhd51bCB/n07IYj6uabGAKTtYZlg==",
                      Role = "DOCTOR",
                      Active = true,
                      Token = null
                  }
             );


            modelBuilder.Entity<Doctor>().HasData(
                new Doctor()
                {
                    Id = 1,
                    Name = "Filip",
                    Surname = "Marinkovic",
                    Email = "doctorfilip@hotmail.com",
                    Specialty = Specialty.Cardiologist,
                    RoomId = 1,
                    StartWorkTime = 8,
                    EndWorkTime = 13,
                    Age = 32
                },
                new Doctor()
                {
                    Id = 2,
                    Name = "Gorana",
                    Surname = "Miljkovic",
                    Email = "gorana.miljkovic@gmail.com",
                    Specialty = Specialty.Anesthesiologist,
                    RoomId = 2,
                    StartWorkTime = 13,
                    EndWorkTime = 20,
                    Age = 29
                },
                new Doctor()
                {
                    Id = 3,
                    Name = "Petar",
                    Surname = "Dobrosavljevic",
                    Email = "petar.dobrosavljevic@gmail.com",
                    Specialty = Specialty.Cardiologist,
                    RoomId = 3,
                    StartWorkTime = 13,
                    EndWorkTime = 20,
                    Age = 40
                },
                new Doctor()
                {
                    Id = 4,
                    Name = "Stefan",
                    Surname = "Simic",
                    Email = "stefan.simic@gmail.com",
                    Specialty = Specialty.Anesthesiologist,
                    RoomId = 4,
                    StartWorkTime = 8,
                    EndWorkTime = 13,
                    Age = 27
                },
                new Doctor()
                {
                    Id = 5,
                    Name = "Bojana",
                    Surname = "Jelic",
                    Email = "bojana.jelic@gmail.com",
                    Specialty = Specialty.Neurosurgeon,
                    RoomId = 5,
                    StartWorkTime = 8,
                    EndWorkTime = 16,
                    Age = 51
                },
                new Doctor()
                {
                    Id = 6,
                    Name = "Katarina",
                    Surname = "Radic",
                    Email = "katarina.radic@gmail.com",
                    Specialty = Specialty.Neurosurgeon,
                    RoomId = 6,
                    StartWorkTime = 14,
                    EndWorkTime = 20,
                    Age = 34
                },
                new Doctor()
                {
                    Id = 7,
                    Name = "Milica",
                    Surname = "Jezdic",
                    Email = "milica.jezdic@gmail.com",
                    Specialty = Specialty.General,
                    RoomId = 7,
                    StartWorkTime = 7,
                    EndWorkTime = 13,
                    Age = 27
                },
                new Doctor()
                {
                    Id = 8,
                    Name = "Zoran",
                    Surname = "Katic",
                    Email = "zoran.katic@gmail.com",
                    Specialty = Specialty.General,
                    RoomId = 8,
                    StartWorkTime = 8,
                    EndWorkTime = 13,
                    Age = 27
                },
                new Doctor()
                {
                    Id = 9,
                    Name = "Bojan",
                    Surname = "Stanic",
                    Email = "bojan.stanic@gmail.com",
                    Specialty = Specialty.General,
                    RoomId = 9,
                    StartWorkTime = 11,
                    EndWorkTime = 19,
                    Age = 35
                });

            base.OnModelCreating(modelBuilder);
        }



    }
}