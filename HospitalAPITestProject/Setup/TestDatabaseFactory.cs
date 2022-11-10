using HospitalAPI;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using HospitalLibrary.Core.Enums;

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
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=admin;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
            context.Database.EnsureCreated();

            //da li uopste pisati integracioni i sta proveravati njime? (da li se napravio blood consumption record u bazi?)
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodConsumptionRecords\";");
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 1, Amount = 10, Type = BloodType.A, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 2, Amount = 11, Type = BloodType.B, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 3, Amount = 12, Type = BloodType.O, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });
            context.BloodConsumptionRecords.Add(new BloodConsumptionRecord { Id = 4, Amount = 13, Type = BloodType.AB, Reason = "some string", CreatedAt = System.DateTime.Now, DoctorId = "DOC1" });

            context.SaveChanges();
        }
    }
}
