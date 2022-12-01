
using IntegrationLibery.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.News
{
    public class NewsService:INewsService
    {
        private readonly INewsRepository _newsRepository;
        //public NewsService() { }
        public NewsService(INewsRepository newsRepository)
        {
             _newsRepository = newsRepository;
        }   

        public void addNews(Message mess)
        {
            _newsRepository.addNews(mess);
        }
        public Message getById(Guid Id)
        {
            return _newsRepository.getById(Id);
        }


        public List<Message> getAll()
        {
           return _newsRepository.getAll();
        }
    }
}
