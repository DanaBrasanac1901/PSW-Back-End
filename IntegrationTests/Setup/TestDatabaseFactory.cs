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

            /* context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"ReportTable\";");


         context.ReportTable.Add(new Report(
             new Guid("3E63FA4E-3A3A-4DEB-ACD1-3F784DE9D90B"),
             DateTime.Now, 
             IntegrationLibrary.Report.Period.Daily,
             DateTime.Today));

         context.ReportTable.Add(new Report( 
             new Guid("9A76E313-E764-4B63-8544-5AAC14155C6A"),
             DateTime.Now, 
             IntegrationLibrary.Report.Period.Monthly,

             DateTime.Today));
         context.ReportTable.Add(new Report(
             new Guid("CB2EA6F8-CCAB-49C9-ABBC-3FC4F8B89A00"),
             DateTime.Today, 
             IntegrationLibrary.Report.Period.EveryTwoMonths,
             DateTime.Today));
*/
            context.SaveChanges();
        }
    }
}