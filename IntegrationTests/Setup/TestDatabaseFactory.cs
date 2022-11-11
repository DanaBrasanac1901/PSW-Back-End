using System;
using System.Linq;
using IntegrationAPI;
using IntegrationLibrary.Report;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DateInterval = Nest.DateInterval;

namespace IntegrationTests.Setup
{
    public class TestDatabaseFactory<TStartup>: WebApplicationFactory<Startup>
    {
        
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<IntegrationDbContext>();

                InitializeDatabase(db);
            });
        }
        
        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<IntegrationDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<IntegrationDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }
        
        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=IntegrationTestDb;Username=postgres;Password=root;";
        }
        
        private static void InitializeDatabase(IntegrationDbContext context)
        {
            context.Database.EnsureCreated();
// period za koji sabiramo potrosenu krv, potrosnja- metoda u modelu koja izracuna = zbir bloodConsumption koju su napravili lekari
// filip da ubaci mzd iz koje banke je uzeta krv?,
// period na koji se generise, adresa banke?,
//pravljenje enuma za interval 

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Reports\";");
     /*       context.Reports.Add(new Report { StartDate = new DateTime(2022,11,1), 
                                             EndDate = new DateTime(2022,11,4), 
                                             ConfigurationDate = DateTime.Now,
                                             GeneratingPeriod = IntegrationLibrary.Report.DateInterval.EveryTwoMonths,
                                             BloodBankId = 55879
                                             
            });
*/

            context.SaveChanges();
        }
    }
}