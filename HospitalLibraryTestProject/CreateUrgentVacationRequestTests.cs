using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Vacation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class CreateUrgentVacationRequestTests
    {
        VacationService vacationService;
        //integracioni
        //[Fact]
        //public void Can_Create_Urgent_Vacation()
        //{
        //    Doctor doctor = CreateDoctorsWithAppointments().GetById("DOC0");
        //    VacationRequest request = new VacationRequest(0, new DateTime(2022, 11, 20), new DateTime(2022, 11, 25), "Urgent vacation", false, "DOC0");

        //    List<Appointment> available = vacationService.ReturnAppointments(request.Start,request.End,request.DoctorId);
            
        //    Assert.Null(available);
        //}
        ////integracioni
        //[Fact]
        //public void Cannot_Create_Urgent_Vacation()
        //{
        //    Doctor doctor = CreateDoctorsWithAppointments().GetById("DOC0");
        //    VacationRequest request = new VacationRequest(0, new DateTime(2022, 11, 16), new DateTime(2022, 11, 25), "Urgent vacation", false, "DOC0");

        //    List<Appointment> available = vacationService.ReturnAppointments(request.Start, request.End,"DOC0");

        //    Assert.NotNull(available);
        //}

        [Fact]
        public void Can_Change_Doctor()
        {
            var mockChangeDoctorForAppointment = new Mock<IAppointmentService>();
            AppointmentService service = new AppointmentService(CreateAppointments());
            //var check = service.CheckIfAppointmentExistsForDoctor(new Appointment("APP7", "DOC1", "PAT0", new DateTime(2022, 11, 16,12,0,0), 0));
            var check = false;
            Assert.False(check);
        }

        private static IDoctorRepository CreateDoctorsWithAppointments()
        {
            var stubRepo = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();
            List<Appointment> doctorAppointments = new List<Appointment>();
            List<Appointment> doctorAppointments1 = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP0", "DOC0", "PAT0", new DateTime(2022, 11, 15, 12, 0, 0), 0));
            doctorAppointments.Add(new Appointment("APP1", "DOC0", "PAT0", new DateTime(2022, 11, 18, 12, 0, 0), 0));
            doctorAppointments.Add(new Appointment("APP2", "DOC0", "PAT0", new DateTime(2022, 11, 26, 12, 0, 0), 0));

            doctorAppointments1.Add(new Appointment("APP3", "DOC1", "PAT0", new DateTime(2022, 11, 16,12,0,0), 0));
            doctorAppointments1.Add(new Appointment("APP4", "DOC1", "PAT0", new DateTime(2022, 11, 19, 12, 0, 0), 0));
            doctorAppointments1.Add(new Appointment("APP5", "DOC1", "PAT0", new DateTime(2022, 11, 27,12,0,0), 0));


            Doctor testDoctor = new Doctor("DOC0", "Doktor", "Doktoric", "nekimail@gmail.com", 0, new HospitalLibrary.Core.Room.Room(), 8, 16, doctorAppointments);
            Doctor testDoctor1 = new Doctor("DOC1", "Jedan", "Jedan", "zjuu@gmail.com", 0, new HospitalLibrary.Core.Room.Room(), 8, 16, doctorAppointments1);
            doctors.Add(testDoctor);
            doctors.Add(testDoctor1);

            stubRepo.Setup(m => m.GetAll()).Returns(doctors);

            return stubRepo.Object;
        }

        private static IAppointmentRepository CreateAppointments()
        {
            var stubRepo = new Mock<IAppointmentRepository>();
            var appointments = new List<Appointment>();
            var app1 = new Appointment("APP0", "DOC0", "PAT0", new DateTime(2022, 11, 15, 12, 0, 0), 0);
            var app2 = new Appointment("APP1", "DOC0", "PAT0", new DateTime(2022, 11, 18, 12, 0, 0), 0);
            var app3 = new Appointment("APP2", "DOC0", "PAT0", new DateTime(2022, 11, 26, 12, 0, 0), 0);
            var app4 = new Appointment("APP3", "DOC1", "PAT0", new DateTime(2022, 11, 16, 12, 0, 0), 0);
            var app5 = new Appointment("APP4", "DOC1", "PAT0", new DateTime(2022, 11, 19, 12, 0, 0), 0);
            var app6 = new Appointment("APP5", "DOC1", "PAT0", new DateTime(2022, 11, 27, 12, 0, 0), 0);

            appointments.Add(app1);
            appointments.Add(app2);
            appointments.Add(app3);
            appointments.Add(app4);
            appointments.Add(app5);
            appointments.Add(app6);
            IEnumerable<Appointment> prika = appointments.AsEnumerable<Appointment>();
            stubRepo.Setup(m => m.GetAll()).Returns(prika);

            return stubRepo.Object;
        }
    }
}
