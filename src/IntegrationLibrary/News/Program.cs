//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//namespace News
//{
//    public class Program
//    {
//        public static List<Message> Messages = new List<Message>();

//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .UseWindowsService()
//                .ConfigureServices((hostContext, services) =>
//                {
//                    services.AddHostedService<TimerService>();
//                    services.AddHostedService<RabbitMQService>();
//                });
//    }
//}
