
using IntegrationLibery.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.News
{
    public interface INewsService
    {
        public void addNews(Message mess);
        public Message getById(Guid id);
        public List <Message> getAll();

    }
}
