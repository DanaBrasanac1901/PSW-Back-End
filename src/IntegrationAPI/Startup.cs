
using IntegrationAPI.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IntegrationLibrary.BloodBank;
using Microsoft.AspNetCore.HttpsPolicy;
using IntegrationAPI.BBConnection;
using System.Linq;
using IntegrationLibrary.Report;

using News;

namespace IntegrationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<IntegrationLibrary.Settings.IntegrationDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("IntegrationDb")));
            services.AddAutoMapper(typeof(Startup));
            //services.AddControllersWithViews();

            services.AddCors((setup) =>
            {
                setup.AddPolicy("default", (options) =>
                {
                    options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });

            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntegrationAPI", Version = "v1" });
            });


            services.AddScoped<IBloodBankService, BloodBankService>();
            services.AddScoped<IBloodBankRepository,BloodBankRepository>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReportRepository, ReportRepository>();
           // services.AddScoped<IEmailService, IEmailService>();
            services.AddScoped<ExceptionMiddleware>();
<<<<<<< HEAD

=======
            services.AddScoped<IReportGeneratorService, ReportGeneratorService>();
            
>>>>>>> 005aa24c90975718aaebdea0edf6c7a9191dbe09

            //services.AddScoped<RabbitMQService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntegrationAPI v1"));
            }
            app.UseCors("default");
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
