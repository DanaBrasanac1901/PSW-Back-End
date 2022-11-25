using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IntegrationLibery.News;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.News;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace IntegrationLibrary.News
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;

        //private readonly INewsService _newsService;
        private readonly IServiceProvider _serviceProvider;
       public RabbitMQService(IServiceProvider serviceProvider)
        {
            _serviceProvider =  serviceProvider;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handler = (INewsService)ActivatorUtilities.CreateInstance(scope.ServiceProvider, typeof(NewsService));
                var _newsService = scope.ServiceProvider.GetRequiredService<INewsService>;
                var factory = new ConnectionFactory() { HostName = "localhost" };
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
                channel.QueueDeclare(queue: "hello",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    var jsonMessage = Encoding.UTF8.GetString(body);
                    Message message;
                    try
                    {   // try deserialize with default datetime format
                        message = JsonConvert.DeserializeObject<Message>(jsonMessage);
                    }
                    catch (Exception)     // datetime format not default, deserialize with Java format (milliseconds since 1970/01/01)
                    {
                        message = JsonConvert.DeserializeObject<Message>(jsonMessage, new MyDateTimeConverter());
                    }
                    Console.WriteLine(" [x] Received {0}", message);
                    // Program.Messages.Add(message);
                    Console.WriteLine(message.Text);
                   // _newsService.addNews(message);
                    handler.addNews(message);

                };
                channel.BasicConsume(queue: "hello",
                                        autoAck: true,
                                        consumer: consumer);
                return base.StartAsync(cancellationToken);

            }

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
