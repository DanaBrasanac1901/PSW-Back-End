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
using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalLibrary.Core.User;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HospitalLibrary.Core.Consiliums;

using HospitalLibrary.Core.Report.Services;
using HospitalLibrary.Core.Report;
using HospitalLibrary.Core.Report.Repositories;

using HospitalLibrary.Core.PasswordHasher;
using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.Statistics;
using HospitalLibrary.Core.ApptSchedulingSession.UseCases;
using HospitalLibrary.Core.ApptSchedulingSession.Storage;

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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audence"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration
                                ["Jwt:Key"]))
                    };
                });

            services.AddMvc();
            services.AddControllers(); //ovo vec ima

            services.AddControllers().AddJsonOptions(x =>
                 x.JsonSerializerOptions.ReferenceHandler = null);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphicalEditor", Version = "v1" });
            });

            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();            
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAvailableAppointmentService, AvailableAppointmentService>();
            services.AddScoped<IScheduleAppointment, ScheduleAppointment>();
            services.AddScoped<IVacationService, VacationService>();
            services.AddScoped<IVacationRepository, VacationRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IEmailSendService, EmailSendService>();

            services.AddScoped<IBloodConsuptionRecordRepository, BloodConsumptionRecordRepository>();
            services.AddScoped<IBloodRequestRepository, BloodRequestRepository>();
            services.AddScoped<IBloodService, BloodService>();

            services.AddScoped<IBloodConsuptionRepository, BloodSupplyRepository>();
            services.AddScoped<IInpatientTreatmentRecordService, InpatientTreatmentRecordService>();
            services.AddScoped<IInpatientTreatmentRecordRepository, InpatientTreatmentRecordRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentService, EquipmentService>();


            services.AddScoped<IBloodConsuptionRepository, BloodSupplyRepository>();
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<IScheduleAppointment,ScheduleAppointment>();
            services.AddScoped<ISchedulingStatisticsService,SchedulingStatisticsService>();


           

            services.AddScoped<IConsiliumRepository, ConsiliumRepository>();
            services.AddScoped<IConsiliumService, ConsiliumService>();


            services.AddScoped<IDrugApplicationService, DrugApplicationService>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<IReportApplicationService, ReportApplicationService>();
            services.AddScoped<ISymptomApplicationService, SymptomApplicationService>();
            services.AddScoped<ISymptomRepository, SymptomRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IDrugApplicationService, DrugApplicationService>();
            services.AddScoped<IDrugPrescriptionRepository, DrugPrescriptionRepository>();

            services.AddScoped<IDrugListRepository, DrugListRepository>();
            services.AddScoped<IDrugListApplicationService, DrugListApplicationService>();


            services.AddScoped<ISymptomListRepository, SymptomListRepository>();
            services.AddScoped<IDrugPrescriptionApplicationService, DrugPrescriptionApplicationService>();


            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventSourcingStatistics, EventSourcingStatistics>();

            services.AddScoped<IHealthMeasurementsService, HealthMeasurementsService>();
            services.AddScoped<IHealthMeasurementsRepository, HealthMeasurementsRepository>();
            services.AddScoped<IPatientHealthMeasurementsService, PatientHealthMeasurementsService>();
            services.AddScoped<IPatientHealthMeasurementsRepository, PatientHealthMeasurementsRepository>();

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
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
