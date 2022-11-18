using IntegrationLibrary.BloodBank;
using IntegrationTests.Integration;
using Nest;
using News;
using System;
using System.Threading;
using Xunit;

namespace IntegrationTests
{
    public class NewsTests
    {
        [Fact]
        public static void RabbitMQ_message_received()
        {
            var fake = new FakeProcessor();
            var cc = new RabbitMQService(fake);
            var cts = new CancellationTokenSource();
            var pp= cc.StartAsync(cts.Token);
            Message m = new Message("fefe",DateTime.Now);

            var producer = new TestPublisher();
            producer.Publish("hello",m );

           // Assert.Equal(m, fake.);



        }
    }
}
