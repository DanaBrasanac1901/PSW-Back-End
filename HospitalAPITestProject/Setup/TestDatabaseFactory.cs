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
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Vacation;
using System;

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

            /*context.Database.ExecuteSqlRaw("truncate table \"HospitalBlood\";");
            context.HospitalBlood.Add(new BloodSupply { Id = 1, Amount = 10, Type = BloodType.A,SourceBank = stojan });
            context.HospitalBlood.Add(new BloodSupply { Id = 2, Amount = 11, Type = BloodType.B, SourceBank = stojan });
            context.HospitalBlood.Add(new BloodSupply { Id = 3, Amount = 12, Type = BloodType.O, SourceBank = stojan });
            context.HospitalBlood.Add(new BloodSupply { Id = 4, Amount = 13, Type = BloodType.AB, SourceBank = stojan });
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodConsumptionRecords\";");
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 1, Amount = 2, Type = BloodType.A, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1",SourceBank = stojan });
            
            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE\"Doctors\";");
            context.Doctors.Add(new Doctor { Id = "DOC2", Name = "Milan", Surname = "Radovic", Email = "radovic@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 16});


            context.SaveChanges();*/
        }
    }
}
