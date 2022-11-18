using IntegrationLibrary.BloodBank;
using News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Integration
{
    public class FakeProcessor:IBloodBankRepository
    {
        public List<Message> Messages { get; set; }

        public FakeProcessor()
        {
            Messages = new List<Message>();
        }

        public void ProcessMessage(string message)
        {
            //Messages.Add(message);
        }

        public IEnumerable<BloodBank> GetAll()
        {
            throw new NotImplementedException();
        }

        public BloodBank GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Create(BloodBank bb)
        {

            throw new NotImplementedException();
        }

        public void Update(BloodBank bb)
        {
            throw new NotImplementedException();
        }

        public void Delete(BloodBank bb)
        {
            throw new NotImplementedException();
        }

        public void AddNews(Message mm)
        {
            throw new NotImplementedException();
        }
    }
}

