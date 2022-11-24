using HospitalAPI;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.Room;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
            //naci bolji nacin za ovo jer truncate ne radi kada imamo foreign keys a brisanje pa pisanje duze traje
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //da li uopste pisati integracioni i sta proveravati njime? (da li se napravio blood consumption record u bazi?)
            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Rooms\";");
            context.Rooms.Add(new Room { Id = 1, Floor = 1, Number = "11" });
            context.Rooms.Add(new Room { Id = 2, Floor = 1, Number = "12" });
            context.Rooms.Add(new Room { Id = 3, Floor = 2, Number = "21" });
            context.Rooms.Add(new Room { Id = 4, Floor = 3, Number = "31" });

            InitializeDoctors(context);
            InitializePatients(context);

            context.SaveChanges();
        }

        private static void InitializeDoctors(HospitalDbContext context)
        {
            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Doctors\";");
            context.Doctors.Add(new Doctor { Id = "1", Name = "Ivan", Surname = "Nikolic", Email = "inik@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 13 });
            context.Doctors.Add(new Doctor { Id = "2", Name = "Milica", Surname = "Todorovic", Email = "mtodorovic@hotmail.com", RoomId = 2, StartWorkTime = 8, EndWorkTime = 13 });
            context.Doctors.Add(new Doctor { Id = "3", Name = "Darko", Surname = "Mitic", Email = "darkomitic@live.com", RoomId = 3, StartWorkTime = 13, EndWorkTime = 20 });
            context.Doctors.Add(new Doctor { Id = "4", Name = "Selena", Surname = "Mirkovic", Email = "selmirkovic@gmail.com", RoomId = 4, StartWorkTime = 13, EndWorkTime = 20 });
        }

        private static void InitializePatients(HospitalDbContext context)
        {
            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Patients\";");
            context.Patients.Add(new Patient { Id = "5", Name = "Janko", Surname="Jankovic", Email = "janki@gmail.com", BloodType = BloodType.A, Allergies = { }, DoctorID="1",Active=true });
            context.Patients.Add(new Patient { Id = "6", Name = "Milan", Surname = "Simic",  Email = "mmilaaan@hotmail.com", BloodType = BloodType.O, Allergies = { }, DoctorID="1",Active=true });
            context.Patients.Add(new Patient { Id = "7", Name = "Nikola", Surname = "Nikolic", Email = "niknik@live.com", BloodType = BloodType.AB, Allergies = { }, DoctorID="2", Active=true });
            context.Patients.Add(new Patient { Id = "8", Name = "Sanja", Surname = "Medic", Email = "medics@gmail.com", BloodType = BloodType.A, Allergies = { },DoctorID="3", Active=true });
            context.Patients.Add(new Patient { Id = "9", Name = "Mirko", Surname = "Kis", Email = "mkis@gmail.com", BloodType = BloodType.B, Allergies = { }, DoctorID = "1", Active = true });
        }
    }
}





