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
            
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Reports\";");
<<<<<<< HEAD
            /*       context.Reports.Add(new Report { StartDate = new DateTime(2022,11,1), 
                                                    EndDate = new DateTime(2022,11,4), 
                                                    ConfigurationDate = DateTime.Now,
                                                    GeneratingPeriod = IntegrationLibrary.Report.DateInterval.EveryTwoMonths,
                                                    BloodBankId = 55879

                   });
       */
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"NewsTable\";");
           
=======
            
            
            context.Reports.Add(new Report(
                new Guid("e2ddfa02610e48e983824b23ac955632"), 
                new Guid(),
                DateTime.Now, 
                IntegrationLibrary.Report.Period.Daily,
                DateTime.Today));
            
            context.Reports.Add(new Report(
                new Guid("e2ddfa02620e48e983824b23ac955632"), 
                new Guid(),
                DateTime.Now, 
                IntegrationLibrary.Report.Period.Monthly,
                
                DateTime.Today));
            context.Reports.Add(new Report(
                new Guid("e2ddfa88610e48e983824b23ac955632") , 
                new Guid(),
                DateTime.Today, 
                IntegrationLibrary.Report.Period.EveryTwoMonths,
                DateTime.Today));
>>>>>>> 005aa24c90975718aaebdea0edf6c7a9191dbe09

            context.SaveChanges();
        }
    }
}