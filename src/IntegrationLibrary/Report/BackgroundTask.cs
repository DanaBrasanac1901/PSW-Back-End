using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IntegrationLibrary.Report
{
    public class BackgroundTask : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<BackgroundTask> _logger;
        
        public BackgroundTask(IServiceProvider serviceProvider, ILogger<BackgroundTask> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    _logger.LogInformation("Generating started {dateTime}", DateTime.Now);
                    var scopedService = scope.ServiceProvider.GetRequiredService<IReportGeneratorService>();
                    scopedService.GeneratePdf();
                    
                   // await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
                     await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
                }

            }
        }

      
    }
}