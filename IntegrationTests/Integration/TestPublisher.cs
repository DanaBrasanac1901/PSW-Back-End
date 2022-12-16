using IntegrationLibery.News;
using Nest;

using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Integration
{
    internal class TestPublisher
    {
        public void Publish(string queueName, Message message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
          
            //    var properties = new BasicProperties();
            //properties.Headers = new Dictionary<string, object>();
            //properties.Headers.Add("senderip", InetAddress.getLocalHost().getHostAddress());
            //properties.Headers.Add("custominfo", "info");

            {
                var JsonMessage = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(JsonMessage);

                channel.BasicPublish(exchange: "",
                                       routingKey: queueName,
                                       basicProperties: null,
                                       body: body);
            }
        }
    }
}
