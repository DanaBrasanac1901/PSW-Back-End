using HospitalAPI;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Appointment;
using System;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Vacation;
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

            context.VacationRequests.Add(new VacationRequest { Id = 1, Start = new DateTime(2023, 3, 5), End = new DateTime(2023, 3, 10), Description = "need rest", Urgency = false, DoctorId = "DOC1", Status = VacationRequestStatus.WaitingForApproval });

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Appointments\";");
            context.Appointments.Add(new Appointment { Id = "APP1", DoctorId = "DOC1", PatientId = "PAT1", Start = new DateTime(2022, 11, 28, 12, 40, 0), Duration = 20, RoomId = 1, Status = AppointmentStatus.Scheduled });
            context.Appointments.Add(new Appointment { Id = "APP2", DoctorId = "DOC1", PatientId = "PAT1", Start = new DateTime(2022, 12, 28, 12, 40, 0), Duration = 20, RoomId = 1, Status = AppointmentStatus.Scheduled });
            context.Appointments.Add(new Appointment { Id = "APP3", DoctorId = "DOC1", PatientId = "PAT1", Start = new DateTime(2023, 2, 5, 12, 40, 0), Duration = 20, RoomId = 1, Status = AppointmentStatus.Scheduled });
            context.Appointments.Add(new Appointment { Id = "APP4", DoctorId = "DOC1", PatientId = "PAT1", Start = new DateTime(2023, 2, 12, 12, 40, 0), Duration = 20, RoomId = 1, Status = AppointmentStatus.Scheduled });

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodConsumptionRecords\";");
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 9, Amount = 10, Type = BloodType.A, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 10, Amount = 11, Type = BloodType.B, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 11, Amount = 12, Type = BloodType.O, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 12, Amount = 13, Type = BloodType.AB, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"HospitalBlood\";");
            context.HospitalBlood.Add(new BloodSupply { Id = 1, Amount = 10, Type = BloodType.A });
            context.HospitalBlood.Add(new BloodSupply { Id = 2, Amount = 11, Type = BloodType.B });
            context.HospitalBlood.Add(new BloodSupply { Id = 3, Amount = 12, Type = BloodType.O });
            context.HospitalBlood.Add(new BloodSupply { Id = 4, Amount = 13, Type = BloodType.AB });


            context.Database.ExecuteSqlRaw("TRUNCATE TABLE\"Doctors\";");
            context.Doctors.Add(new Doctor { Id = "DOC1", Name = "Milan", Surname = "Radovic", Email = "radovic@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 16, Appointments = new System.Collections.Generic.List<Appointment>(), VacationRequests = new System.Collections.Generic.List<VacationRequest>() });

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE\"Rooms\";");
            context.Rooms.Add(new HospitalLibrary.Core.Room.Room { Id = 1, Number = "ROOM1", Floor = 1 });

            
            context.SaveChanges();
        }
    }
}
