using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBank
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly IntegrationDbContext integrationDbContext;

        public BloodBankRepository(IntegrationDbContext context)
        {
            integrationDbContext = context;
        }

        public async void Create(BloodBank bb)
        {
            await integrationDbContext.BloodBankTable.AddAsync(bb);
            await integrationDbContext.SaveChangesAsync();

        }

        public void Delete(BloodBank bb)
        {
            integrationDbContext.Remove(bb);

            integrationDbContext.SaveChangesAsync();
        }

        public IEnumerable<BloodBank> GetAll()
        {

            return integrationDbContext.BloodBankTable.ToList();
        }

        public BloodBank GetById(Guid id)
        {
            return integrationDbContext.BloodBankTable.FirstOrDefault(x => x.Id == id);
        }

        public void Update(BloodBank bb)
        {
            integrationDbContext.SaveChangesAsync();
        }
    }
}
