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
            
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"ReportTable\";");
            
            
            context.ReportTable.Add(new Report(
                new Guid(),
                DateTime.Now, 
                IntegrationLibrary.Report.Period.Daily,
                DateTime.Today));
            
            context.ReportTable.Add(new Report( 
                new Guid(),
                DateTime.Now, 
                IntegrationLibrary.Report.Period.Monthly,
                
                DateTime.Today));
            context.ReportTable.Add(new Report(
                new Guid(),
                DateTime.Today, 
                IntegrationLibrary.Report.Period.EveryTwoMonths,
                DateTime.Today));

            context.SaveChanges();
        }
    }
}