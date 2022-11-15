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
        
        
        public DbSet<Report.Report> Reports { get; set; }
        public IntegrationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<IntegrationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BloodBank.BloodBank bank1 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "edhb", Apikey = "efwfe", Email = "andykesic123@gmail.com", IsConfirmed = true };
            BloodBank.BloodBank bank2 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "fewsfd", Apikey = "dqad", Email = "andykesic123@gmail.com", IsConfirmed = true };
           
    BloodBank.BloodBank bank3 = new BloodBank.BloodBank() { Id = Guid.NewGuid(), Username = "101A", Password = "fcsde", Apikey = "ads", Email = "andykesic123@gmail.com", IsConfirmed = true };

            modelBuilder.Entity < BloodBank.BloodBank>().HasData(
               bank1, bank2, bank3
            );
            //modelBuilder.Entity<BloodBank.BloodBank>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //} );
            //modelBuilder.Entity<BloodBank.BloodBank>()
            //.Property(b => b.Id)
            //.ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);


        }
        }
}
