using HospitalAPI;

using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.User;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Vacation;
using System;
using HospitalLibrary.Core.InpatientTreatmentRecord;

namespace HospitalTests.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<HospitalDbContext>();

                InitializeDatabase(db);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=password;";
        }
        
        private static void InitializeDatabase(HospitalDbContext context)
        {

            context.Database.EnsureCreated();
            

            context.SaveChanges();
            /*
           // context.Database.ExecuteSqlRaw("TRUNCATE TABLE\"Rooms\";");
            context.Rooms.Add(new Room { Id = 1, Number = "101A", Floor = 1 });

            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE\"Equipment\";");
            context.Equipment.Add(new Equipment { Id = "1", Type = EquipmentType.BED, Quantity = 1, RoomId = 1 });
            context.Equipment.Add(new Equipment { Id = "2", Type = EquipmentType.BANDAGES, Quantity = 1, RoomId = 1 });
            context.Equipment.Add(new Equipment { Id = "3", Type = EquipmentType.MEDICINE, Quantity = 5, RoomId = 1 });


            context.Database.ExecuteSqlRaw("TRUNCATE TABLE\"InpatientTreatmentRecords\";");
            context.InpatientTreatmentRecords.Add(new InpatientTreatmentRecord { Id = "ITREC1", DoctorID = "DOC1", PatientID = "PAT1", RoomID = "1", BedID = "B1", AdmissionDate = System.DateTime.Now, Status = true, Therapy = "lekovi", AdmissionReason = "bolestan", DischargeReason = "", DischargeDate = new DateTime(2023, 1, 1) });
            context.InpatientTreatmentRecords.Add(new InpatientTreatmentRecord { Id = "ITREC2", DoctorID = "DOC1", PatientID = "PAT2", RoomID = "1", BedID = "B2", AdmissionDate = System.DateTime.Now, Status = true, Therapy = "lekovi", AdmissionReason = "bolestan", DischargeReason = "", DischargeDate = new DateTime(2023, 1, 10) });
            context.InpatientTreatmentRecords.Add(new InpatientTreatmentRecord { Id = "ITREC3", DoctorID = "DOC1", PatientID = "PAT3", RoomID = "2", BedID = "B3", AdmissionDate = System.DateTime.Now, Status = true, Therapy = "lekovi", AdmissionReason = "bolestan", DischargeReason = "", DischargeDate = new DateTime(2023, 1, 3) });
            context.InpatientTreatmentRecords.Add(new InpatientTreatmentRecord { Id = "ITREC4", DoctorID = "DOC1", PatientID = "PAT4", RoomID = "2", BedID = "B4", AdmissionDate = System.DateTime.Now, Status = true, Therapy = "lekovi", AdmissionReason = "bolestan", DischargeReason = "", DischargeDate = new DateTime(2023, 1, 15) });






            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE\"Doctors\";");
            context.Doctors.Add(new Doctor { Id = "DOC1", Name = "Milan", Surname = "Radovic", Email = "radovic@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 16, Appointments = new System.Collections.Generic.List<Appointment>(), VacationRequests = new System.Collections.Generic.List<VacationRequest>() });

            //context.Database.ExecuteSqlRaw("truncate table \"HospitalBlood\";");
            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodConsumptionRecords\";");
            //context.Database.ExecuteSqlRaw("truncate table \"VacationRequests\";");
            context.HospitalBlood.Add(new BloodSupply { Id = 1, Amount = 10, Type = BloodType.A });
            context.HospitalBlood.Add(new BloodSupply { Id = 2, Amount = 11, Type = BloodType.B });
            context.HospitalBlood.Add(new BloodSupply { Id = 3, Amount = 12, Type = BloodType.O });

            context.HospitalBlood.Add(new BloodSupply { Id = 4, Amount = 13, Type = BloodType.AB });
           // context.Database.ExecuteSqlRaw("truncate table \"Appointments\";");
            context.Appointments.Add(new Appointment { Id = "APP1", DoctorId = "DOC1", PatientId = "PAT1", Start = new DateTime(2022, 11, 28, 12, 40, 0), Duration = 20, RoomId = 1, Status = AppointmentStatus.Scheduled });
            context.Appointments.Add(new Appointment { Id = "APP2", DoctorId = "DOC2", PatientId = "PAT1", Start = new DateTime(2022, 12, 28, 13, 0, 0), Duration = 20, RoomId = 1, Status = AppointmentStatus.Scheduled });
            context.Appointments.Add(new Appointment { Id = "APP3", DoctorId = "DOC2", PatientId = "PAT1", Start = new DateTime(2023, 2, 5, 12, 40, 0), Duration = 20, RoomId = 1, Status = AppointmentStatus.Scheduled });
            context.Appointments.Add(new Appointment { Id = "APP4", DoctorId = "DOC1", PatientId = "PAT1", Start = new DateTime(2023, 2, 12, 12, 40, 0), Duration = 20, RoomId = 1, Status = AppointmentStatus.Scheduled });
            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodConsumptionRecords\";");
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 9, Amount = 10, Type = BloodType.A, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });

            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 10, Amount = 11, Type = BloodType.B, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 11, Amount = 12, Type = BloodType.O, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 12, Amount = 13, Type = BloodType.AB, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });

           
            




            //context.Database.ExecuteSqlRaw("truncate table \"BloodConsumptionRecords\";");
            /*context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 5, Amount = 10, Type = BloodType.A, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 6, Amount = 11, Type = BloodType.B, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 7, Amount = 12, Type = BloodType.AB, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 8, Amount = 13, Type = BloodType.O, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });*/


            //context.VacationRequests.Add(new VacationRequest { Id = 49, Start = new DateTime(2023, 1, 1), End = new DateTime(2023, 1, 14), Description = "holidays", Urgency = true, DoctorId = "DOC1" });

            //context.VacationRequests.Add(new VacationRequest { Id = 1, Start = new DateTime(2023, 3, 5), End = new DateTime(2023, 3, 10), Description = "need rest", Urgency = false, DoctorId = "DOC1", Status = VacationRequestStatus.WaitingForApproval, RejectionReason = "" });
            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE\"Rooms\";");
        }


        //private static void InitializeUsers(HospitalDbContext context)
        //{
        //    context.Users.Add(new User { Id = 1, Name = "Ivan", Surname = "Nikolic", Email = "inik@gmail.com",Password = "pass1", Role ="DOCTOR"});
        //    context.Users.Add(new User { Id = 2, Name = "Milica", Surname = "Todorovic", Email = "mtodorovic@hotmail.com", Password = "pass2", Role = "DOCTOR" });
        //    context.Users.Add(new User { Id = 3, Name = "Darko", Surname = "Mitic", Email = "darkomitic@live.com", Password = "pass3", Role = "DOCTOR" });
        //    context.Users.Add(new User { Id = 4, Name = "Selena", Surname = "Mirkovic", Email = "selmirkovic@gmail.com", Password = "pass4", Role = "DOCTOR" });
        //    context.Users.Add(new User { Id = 5, Name = "Janko", Surname = "Jankovic", Email = "janki@gmail.com", Password = "pass5", Role = "PATIENT" });
        //    context.Users.Add(new User { Id = 6, Name = "Milan", Surname = "Simic", Email = "mmilaaan@hotmail.com", Password = "pass6", Role = "PATIENT" });
        //    context.Users.Add(new User { Id = 7, Name = "Nikola", Surname = "Nikolic", Email = "niknik@live.com", Password = "pass7", Role = "PATIENT" });
        //    context.Users.Add(new User { Id = 8, Name = "Sanja", Surname = "Medic", Email = "medics@gmail.com", Password = "pass8", Role = "PATIENT" });
        //    context.Users.Add(new User { Id = 9, Name = "Mirko", Surname = "Kis", Email = "mkis@gmail.com", Password = "pass9", Role = "PATIENT" });
        //}

        //private static void InitializeDoctors(HospitalDbContext context)
        //{
        //    context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Doctors\";");
        //    context.Doctors.Add(new Doctor { Id = "1", Name = "Ivan", Surname = "Nikolic", Email = "inik@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 13 });
        //    context.Doctors.Add(new Doctor { Id = "2", Name = "Milica", Surname = "Todorovic", Email = "mtodorovic@hotmail.com", RoomId = 2, StartWorkTime = 8, EndWorkTime = 13 });
        //    context.Doctors.Add(new Doctor { Id = "3", Name = "Darko", Surname = "Mitic", Email = "darkomitic@live.com", RoomId = 3, StartWorkTime = 13, EndWorkTime = 20 });
        //    context.Doctors.Add(new Doctor { Id = "4", Name = "Selena", Surname = "Mirkovic", Email = "selmirkovic@gmail.com", RoomId = 4, StartWorkTime = 13, EndWorkTime = 20 });
        //}

        //private static void InitializePatients(HospitalDbContext context)
        //{
        //    context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Patients\";");
        //    context.Patients.Add(new Patient { Id = "5", Name = "Janko", Surname="Jankovic", Email = "janki@gmail.com", BloodType = BloodType.A, Allergies = { }, DoctorID="1",Active=true });
        //    context.Patients.Add(new Patient { Id = "6", Name = "Milan", Surname = "Simic",  Email = "mmilaaan@hotmail.com", BloodType = BloodType.O, Allergies = { }, DoctorID="1",Active=true });
        //    context.Patients.Add(new Patient { Id = "7", Name = "Nikola", Surname = "Nikolic", Email = "niknik@live.com", BloodType = BloodType.AB, Allergies = { }, DoctorID="2", Active=true });
        //    context.Patients.Add(new Patient { Id = "8", Name = "Sanja", Surname = "Medic", Email = "medics@gmail.com", BloodType = BloodType.A, Allergies = { },DoctorID="3", Active=true });
        //    context.Patients.Add(new Patient { Id = "9", Name = "Mirko", Surname = "Kis", Email = "mkis@gmail.com", BloodType = BloodType.B, Allergies = { }, DoctorID = "1", Active = true });

        //}*/

    }
}





