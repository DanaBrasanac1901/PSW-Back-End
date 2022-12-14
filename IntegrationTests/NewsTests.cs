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
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Patient;
using IntegrationAPI.Controllers;
using AutoMapper;
using Newtonsoft.Json;
using System.Reflection;

namespace IntegrationTests
{
    public class NewsTests:BaseIntegrationTest
    {

        private readonly IBloodBankRepository bloodBankRepository;

        public object Object1 { get; private set; }
        public object Object2 { get; private set; }

        public NewsTests(TestDatabaseFactory<Startup> factory) : base(factory)
        { 
        }
        private static RabbitMQService SetupRabbit(IServiceScope scope)
        {
            return new RabbitMQService(scope.ServiceProvider);

        }

        private static BloodBankController SetupController(IServiceScope scope)
        {
            return new BloodBankController(scope.ServiceProvider.GetRequiredService<IBloodBankService>(), scope.ServiceProvider.GetRequiredService<IMapper>());

        }
        [Fact]
        public  void RabbitMQ_message_received()
        {

            using var scope = Factory.Services.CreateScope();
            var service = SetupRabbit(scope);
            var controller = SetupController(scope);


            var cts = new CancellationTokenSource();

            var pp= service.StartAsync(cts.Token);
            Message m = new Message("fefe",DateTime.Now);

            var producer = new TestPublisher();
            producer.Publish("hello",m );

            Object1 = m;
            Object2 = controller.GetByIdNews(m.Id);
            Assert.Equal(controller.GetByIdNews(m.Id).Id, m.Id);

           



        }
    }
}
