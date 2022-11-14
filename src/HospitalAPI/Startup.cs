using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.Vacation;

namespace HospitalAPI
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
            services.AddDbContext<HospitalDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("HospitalDb")).UseLazyLoadingProxies());

            var emailConfig = Configuration
            .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            
            services.AddControllers().AddJsonOptions(x =>
                 x.JsonSerializerOptions.ReferenceHandler = null);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphicalEditor", Version = "v1" });
            });

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            services.AddScoped<IVacationService, VacationService>();
            services.AddScoped<IVacationRepository, VacationRepository>();

            services.AddScoped<IEmailSendService, EmailSendService>();

            services.AddScoped<IBloodConsuptionRecordRepository, BloodConsumptionRecordRepository>();
            services.AddScoped<IBloodRequestRepository, BloodRequestRepository>();
            services.AddScoped<IBloodService, BloodService>();
            services.AddScoped<IBloodSupplyRepository, BloodSupplyRepository>();
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
