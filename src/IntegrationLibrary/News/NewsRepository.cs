using IntegrationLibrary.Settings;
using IntegrationLibrary.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IntegrationLibery.News;

namespace IntegrationLibrary.News
{
    public class NewsRepository : INewsRepository
    {
        private readonly IntegrationDbContext integrationDbContext;

        public NewsRepository(IntegrationDbContext context)
        {
            integrationDbContext = context;
        }

        public void addNews(Message mess)
        {
            integrationDbContext.NewsTable.AddAsync(mess);
            integrationDbContext.SaveChangesAsync();
        }

        public List<Message> getAll()
        {
            return integrationDbContext.NewsTable.ToList();
        }

        public Message getById(Guid id)
        {
            return integrationDbContext.NewsTable.FirstOrDefault(x => x.Id == id);
        }
       
    }
}
