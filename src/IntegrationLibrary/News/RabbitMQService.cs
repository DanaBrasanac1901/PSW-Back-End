using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using crypto;
using Elasticsearch.Net;
using IntegrationLibery.News;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.News;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static Org.BouncyCastle.Math.EC.ECCurve;
using IConnection = RabbitMQ.Client.IConnection;
using IModel = RabbitMQ.Client.IModel;

namespace IntegrationLibrary.News
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        private readonly IntegrationDbContext integrationDbContext;
        private readonly INewsRepository _newRepository;
        private readonly IServiceProvider _serviceProvider;
         public RabbitMQService(IServiceProvider serviceProvider)
         {
             _serviceProvider =  serviceProvider;
         }
       // public RabbitMQService()
        //{
        //   
        //}

        public override Task StartAsync(CancellationToken cancellationToken)
        {
                var scope = _serviceProvider.CreateScope();
           
                var handler = (INewsService)ActivatorUtilities.CreateInstance(scope.ServiceProvider, typeof(NewsService));
           
                //var _newsService = scope.ServiceProvider.GetRequiredService<INewsService>;
                //NewsService _newsService = new NewsService(_newRepository);
               
                var factory = new ConnectionFactory() { HostName = "localhost" };
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
               /* channel.QueueDeclare(queue: "hello",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);
                channel.ExchangeDeclare(exchange: "direct_logs",
                                          type: "direct");
                channel.QueueBind(queue: "hello",
                                  exchange: "direct_logs",
                                  routingKey: "hello");*/
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    var jsonMessage = Encoding.UTF8.GetString(body);
                   
                     Message message= new Message();
                     try
                     {   // try deserialize with default datetime format
                        message = JsonConvert.DeserializeObject<Message>(jsonMessage);
                     }
                     catch (Exception)     // datetime format not default, deserialize with Java format (milliseconds since 1970/01/01)
                    {
                        message = JsonConvert.DeserializeObject<Message>(jsonMessage, new MyDateTimeConverter());
                    }

                   

                    handler.addNews(message);

                };
                channel.BasicConsume(queue: "hello",
                                        autoAck: true,
                                        consumer: consumer);
                return base.StartAsync(cancellationToken);

            

        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
