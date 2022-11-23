using IntegrationLibrary.BloodBank;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext: DbContext
    {

        public DbSet<BloodBank.BloodBank> BloodBankTable { get; set; }
        
        
        public DbSet<Report.Report> ReportTable { get; set; }
        public IntegrationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<IntegrationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BloodBank.BloodBank bank1 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "edhb", Apikey = "efwfe", Email = "andykesic123@gmail.com", IsConfirmed = true };
            BloodBank.BloodBank bank2 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "fewsfd", Apikey = "dqad", Email = "andykesic123@gmail.com", IsConfirmed = true };
            BloodBank.BloodBank bank3 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "fcsde", Apikey = "ads", Email = "andykesic123@gmail.com", IsConfirmed = true };

           Report.Report report1 = new Report.Report( 
                                               bank3.Id,
                                                        DateTime.Now, 
                                                        Report.Period.Daily,
                                                        DateTime.Today);
            
            Report.Report report2 = new Report.Report(bank1.Id, 
                                                          DateTime.Now, 
                                                        Report.Period.Monthly,
                                                DateTime.Today);

            Report.Report report3 = new Report.Report(bank2.Id , 
                                                    DateTime.Today, 
                                                    Report.Period.EveryTwoMonths,
                                        DateTime.Today);

            
            
            modelBuilder.Entity < BloodBank.BloodBank>().HasData(
               bank1, bank2, bank3
            );
            
            modelBuilder.Entity < Report.Report>().HasData(
                report1, report2, report3
            );
            //modelBuilder.Entity<BloodBank.BloodBank>()
            //.Property(b => b.Id)
            //.ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);


        }
        }
}
