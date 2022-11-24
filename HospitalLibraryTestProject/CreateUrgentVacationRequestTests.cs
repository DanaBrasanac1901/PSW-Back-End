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
using HospitalLibrary.Core.Doctor.DTOS;

namespace HospitalLibraryTestProject
{
    public class CreateUrgentVacationRequestTests
    { 
        //testovi
        [Fact]
        public void Cannot_Change_Doctor()
        {
            var mockChangeDoctorForAppointment = new Mock<IAppointmentService>();
            AppointmentService service = new AppointmentService(CreateAppointments());
            var check = service.CheckIfAppointmentExistsForDoctor("DOC1", new DateTime(2022, 11, 16, 12, 0, 0));
            Assert.False(check);
        }

        [Fact]
        public void Can_Change_Doctor()
        {
            var mockChangeDoctorForAppointment = new Mock<IAppointmentService>();
            AppointmentService service = new AppointmentService(CreateAppointments());

            var check = service.CheckIfAppointmentExistsForDoctor("DOC1", new DateTime(2022, 11, 16, 12, 20, 0));
            Assert.True(check);
        }

        [Fact]
        public void Check_If_Doctor_Is_Busy()
        {
            var mockCheckIfDoctorIsBusy = new Mock<IDoctorService>();
            DoctorService service = new DoctorService(CreateDoctorsWithAppointments());
            var check = service.CheckIfDoctorIsBusy(ListOfAppointmentsForOneDoctor(), new DateTime(2022, 11, 15, 12, 0, 0));
            Assert.False(check);
        }

        [Fact]
        public void Check_If_Doctor_Is_Not_Busy()
        {
            var mockCheckIfDoctorIsBusy = new Mock<IDoctorService>();
            DoctorService service = new DoctorService(CreateDoctorsWithAppointments());
            var check = service.CheckIfDoctorIsBusy(ListOfAppointmentsForOneDoctor(), new DateTime(2022, 11, 15, 12, 20, 0));
            Assert.True(check);
        }

        [Fact]
        public void Get_Appointments_Urgent_Vacation()
        {
            var mockGetAppointmentsUrgentVacation = new Mock<IDoctorService>();
            DoctorService service = new DoctorService(CreateDoctorsWithAppointments());
            List<DateTime> startAndEnd = new List<DateTime>();
            startAndEnd.Add(new DateTime(2022, 11, 14, 0, 0, 0));
            startAndEnd.Add(new DateTime(2023, 11, 30, 0, 0, 0));
            var appointmentsList = service.ReturnListGetAppointmentsUrgentVacation(ListOfAppointmentsForOneDoctor(), startAndEnd);
            Assert.NotEmpty(appointmentsList);
        }

        [Fact]
        public void Do_Not_Get_Appointments_Urgent_Vacation()
        {
            var mockGetAppointmentsUrgentVacation = new Mock<IDoctorService>();
            DoctorService service = new DoctorService(CreateDoctorsWithAppointments());
            List < DateTime > startAndEnd= new List<DateTime>();
            startAndEnd.Add(new DateTime(2022, 12, 30, 0, 0, 0));
            startAndEnd.Add(new DateTime(2023, 1, 30, 0, 0, 0));
            var appointmentsList = service.ReturnListGetAppointmentsUrgentVacation(ListOfAppointmentsForOneDoctor(), startAndEnd);
            Assert.Empty(appointmentsList);
        }

        [Fact] 
        public void Check_If_Appointment_Is_In_Range()
        {
            var mockCheckIfAppointmentIsInRange = new Mock<IVacationService>();
            VacationService service = new VacationService(CreateVacations(),CreateDoctorsWithAppointments(),CreateAppointments());
            var check = service.CheckIfAppointmentIsInRange(new Appointment("APP0", "DOC0", "PAT0", new DateTime(2022, 11, 15, 12, 0, 0), 0),
                new DateTime(2022, 11, 14, 0, 0, 0), new DateTime(2023, 11, 30, 0, 0, 0));
            Assert.True(check);
        }

        [Fact]
        public void Check_If_Appointment_Is_Not_In_Range()
        {
            var mockCheckIfAppointmentIsInRange = new Mock<IVacationService>();
            VacationService service = new VacationService(CreateVacations(), CreateDoctorsWithAppointments(), CreateAppointments());
            var check = service.CheckIfAppointmentIsInRange(new Appointment("APP0", "DOC0", "PAT0", new DateTime(2022, 11, 15, 12, 0, 0), 0),
                new DateTime(2022, 12, 14, 0, 0, 0), new DateTime(2023, 12, 30, 0, 0, 0));
            Assert.False(check);
        }

        [Fact]
        public void Is_Urgent_Available()
        {
            VacationService service = new VacationService(CreateVacations(), CreateDoctorsWithAppointments(), CreateAppointments());
            var check = service.IsUrgentAvailable(new DateTime(2023, 12, 20, 0, 0, 0), new DateTime(2023, 12, 25, 0, 0, 0),"DOC0");
            Assert.True(check);
        }

        [Fact]
        public void Is_Not_Urgent_Available()
        {
            VacationService service = new VacationService(CreateVacations(), CreateDoctorsWithAppointments(), CreateAppointments());
            var check = service.IsUrgentAvailable(new DateTime(2022, 12, 20, 0, 0, 0), new DateTime(2022, 12, 25, 0, 0, 0), "DOC0");
            Assert.False(check);
        }

        [Fact]
        public void Date_Is_In_Future()
        {
            VacationService service = new VacationService(CreateVacations(), CreateDoctorsWithAppointments(), CreateAppointments());
            var check = service.DateIsInFuture(new DateTime(2030, 1, 1, 0, 0, 0));
            Assert.True(check);
        }

        [Fact]
        public void Date_Is_Not_In_Future()
        {
            VacationService service = new VacationService(CreateVacations(), CreateDoctorsWithAppointments(), CreateAppointments());
            var check = service.DateIsInFuture(DateTime.Now);
            Assert.False(check);
        }

        [Fact]
        public void Start_Is_Before_End()
        {
            VacationService service = new VacationService(CreateVacations(), CreateDoctorsWithAppointments(), CreateAppointments());
            var check = service.StartIsBeforeEnd(DateTime.Now, DateTime.Now.AddSeconds(1));
            Assert.True(check);
        }

        [Fact]
        public void Start_Is_Not_Before_End()
        {
            VacationService service = new VacationService(CreateVacations(), CreateDoctorsWithAppointments(), CreateAppointments());
            var check = service.StartIsBeforeEnd(DateTime.Now.AddSeconds(1), DateTime.Now);
            Assert.False(check);
        }

        //baze,liste....
        private static ICollection<Appointment> ListOfAppointmentsForOneDoctor()
        {
            ICollection<Appointment> doctorAppointments = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP0", "DOC0", "PAT0", new DateTime(2022, 11, 15, 12, 0, 0), 0));
            doctorAppointments.Add(new Appointment("APP1", "DOC0", "PAT0", new DateTime(2022, 11, 18, 12, 0, 0), 0));
            doctorAppointments.Add(new Appointment("APP2", "DOC0", "PAT0", new DateTime(2022, 11, 26, 12, 0, 0), 0));
            return doctorAppointments;
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
            stubRepo.Setup(m => m.GetById("DOC0")).Returns(testDoctor);
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
            stubRepo.Setup(m => m.GetAll()).Returns(appointments.AsEnumerable<Appointment>());

            return stubRepo.Object;
        }

        private static IVacationRepository CreateVacations()
        {
            var stubRepo = new Mock<IVacationRepository>();
            var vacations = new List<VacationRequest>();
            var vac1 = new VacationRequest(1, new DateTime(2022, 12, 20, 0, 0, 0), new DateTime(2023, 1, 10, 12, 0, 0),"Opis",true,"DOC0","", HospitalLibrary.Core.Enums.VacationRequestStatus.Accepted);
            var vac2 = new VacationRequest(1, new DateTime(2022, 12, 1, 12, 0, 0), new DateTime(2022, 12, 10, 12, 0, 0), "Opis", false, "DOC1", "", HospitalLibrary.Core.Enums.VacationRequestStatus.WaitingForApproval);

            vacations.Add(vac1);
            vacations.Add(vac2);
            stubRepo.Setup(m => m.GetAll()).Returns(vacations.AsEnumerable<VacationRequest>());

            return stubRepo.Object;
        }
    }
}
