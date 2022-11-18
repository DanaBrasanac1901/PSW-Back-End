using IntegrationLibrary.BloodBank;

using Microsoft.EntityFrameworkCore;
//sing PrimerServis;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext: DbContext
    {

        public DbSet<BloodBank.BloodBank> BloodBankTable { get; set; }
<<<<<<< HEAD
        public DbSet<News.Message> NewsTable { get; set; }
=======
        
        
        public DbSet<Report.Report> Reports { get; set; }
>>>>>>> 005aa24c90975718aaebdea0edf6c7a9191dbe09
        public IntegrationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<IntegrationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BloodBank.BloodBank bank1 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "edhb", Apikey = "efwfe", Email = "andykesic123@gmail.com", IsConfirmed = true };
            BloodBank.BloodBank bank2 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "fewsfd", Apikey = "dqad", Email = "andykesic123@gmail.com", IsConfirmed = true };
            BloodBank.BloodBank bank3 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "fcsde", Apikey = "ads", Email = "andykesic123@gmail.com", IsConfirmed = true };
            BloodBank.BloodBank bank4 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "fcsde", Apikey = "ads", Email = "andykesic123@gmail.com", IsConfirmed = true };
            modelBuilder.Entity < BloodBank.BloodBank>().HasData(
               bank1, bank2, bank3
            );
            News.Message mess = new News.Message("doniraj krv", DateTime.Now) ;
            modelBuilder.Entity<News.Message>().HasData(
              mess
            );
            modelBuilder.Entity<News.Message>(entity =>
            {
               entity.HasKey(e => e.Timestamp);
            } );
            //modelBuilder.Entity<BloodBank.BloodBank>()
            //.Property(b => b.Id)
            //.ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);


        }
        }
}
