
using HospitalLibrary.Core.TenderOffer;
using IntegrationLibery.News;
using IntegrationLibrary.BloodBank;

using Microsoft.EntityFrameworkCore;
//sing PrimerServis;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext: DbContext
    {

        public DbSet<BloodBank.BloodBank> BloodBankTable { get; set; }

        public DbSet<Message> NewsTable { get; set; }


        public DbSet<HospitalLibrary.Core.Tender.Tender> Tenders { get; set; }

        public DbSet<TenderOffer> TenderOffers { get; set; }

        public DbSet<Report.Report> ReportTable { get; set; }

        public IntegrationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<IntegrationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        
            Message mess = new Message("doniraj krv", DateTime.Now) ;
            modelBuilder.Entity<Message>().HasData(
              mess
            );
            modelBuilder.Entity<Message>(entity =>
            {
               entity.HasKey(e => e.Timestamp);
            } );

            BloodBank.BloodBank bank1 = new BloodBank.BloodBank() { Id = new Guid("2D4894B6-02E4-4288-A3D3-089489563190"), Username = "101A", Password = "edhb", Apikey = "efwfe", Email = "andykesic123@gmail.com", IsConfirmed = true };
            BloodBank.BloodBank bank2 = new BloodBank.BloodBank() { Id = new Guid("55510651-D36E-444D-95FB-871E0902CD7E"), Username = "101A", Password = "fewsfd", Apikey = "dqad", Email = "andykesic123@gmail.com", IsConfirmed = true };
            BloodBank.BloodBank bank3 = new BloodBank.BloodBank() { Id = new Guid("A60460FE-0D33-478D-93B3-45D424079E66"), Username = "101A", Password = "fcsde", Apikey = "ads", Email = "andykesic123@gmail.com", IsConfirmed = true };

            
            Report.Report report2 = new Report.Report(bank1.Id, 
                new DateTime(2022, 11,23), 
                                                Report.Period.Daily,
                                                new DateTime(2022, 11,23));

            Report.Report report3 = new Report.Report(bank2.Id , 
                new DateTime(2022, 10,10), 
                                                    Report.Period.EveryTwoMonths,
                                                    new DateTime(2022, 10,17));

            
            
            modelBuilder.Entity < BloodBank.BloodBank>().HasData(
               bank1, bank2, bank3
            );
            
            modelBuilder.Entity < Report.Report>().HasData(
                report2, report3
            );
            modelBuilder.Entity<TenderOffer>().HasNoKey();
            //modelBuilder.Entity<BloodBank.BloodBank>()
            //.Property(b => b.Id)
            //.ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);


        }
        }
}
