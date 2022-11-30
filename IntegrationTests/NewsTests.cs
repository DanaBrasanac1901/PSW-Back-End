using IntegrationAPI;
using IntegrationLibrary.News;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.Report;
using IntegrationTests.Integration;
using IntegrationTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using Nest;

using System;
using System.Threading;
using Xunit;
using IntegrationLibery.News;

namespace IntegrationTests
{
    public class NewsTests:BaseIntegrationTest
    {

        private readonly IBloodBankRepository bloodBankRepository;
        public NewsTests(TestDatabaseFactory<Startup> factory) : base(factory)
        { 
        }

        [Fact]
        public  void RabbitMQ_message_received()
        {   
            
            var service = Factory.Services.CreateScope().ServiceProvider.GetRequiredService<RabbitMQService>();
            //var fake = new FakeProcessor();
            
            var service2=Factory.Services.CreateScope().ServiceProvider.GetRequiredService<NewsService>();

            var cts = new CancellationTokenSource();

            var pp= service.StartAsync(cts.Token);
            Message m = new Message("fefe",DateTime.Now);

            var producer = new TestPublisher();
            producer.Publish("hello",m );

            Assert.Equal(m,service2.getById(m.Id));



        }
    }
}
