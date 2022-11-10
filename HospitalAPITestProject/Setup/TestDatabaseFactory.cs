using HospitalAPI;
using HospitalLibrary.Core.Room;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=super;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
            context.Database.EnsureCreated();

            //da li uopste pisati integracioni i sta proveravati njime? (da li se napravio blood consumption record u bazi?)
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Rooms\";");
            context.Rooms.Add(new Room { Id = 1, Floor = 1, Number = "11" });
            context.Rooms.Add(new Room { Id = 2, Floor = 1, Number = "12" });
            context.Rooms.Add(new Room { Id = 3, Floor = 2, Number = "21" });
            context.Rooms.Add(new Room { Id = 4, Floor = 3, Number = "31" });

            context.SaveChanges();
        }
    }
}
