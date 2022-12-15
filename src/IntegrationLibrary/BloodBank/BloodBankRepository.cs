using IntegrationLibery.News;
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
            integrationDbContext.BloodBankTable.AddAsync(bb);
            integrationDbContext.SaveChangesAsync();

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
        public void addNews(Message mess)
        {
            integrationDbContext.NewsTable.AddAsync(mess);
            integrationDbContext.SaveChangesAsync();
        }

        public IEnumerable<Message> getNews()
        {
            return integrationDbContext.NewsTable.ToList();
        }

        public Message getByIdNews(Guid id)
        {
           return integrationDbContext.NewsTable.FirstOrDefault(x => x.Id == id);
        }
    }
}
