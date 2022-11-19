using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using Shouldly;
using System;
using Xunit;
using System.Collections.Generic;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Room;

namespace HospitalLibraryTestProject
{
    public class CreateVacationRequestTests
    {
        [Fact]
        public void Can_create_non_urgent()
        {
            Doctor doctor = CreateDoctorWithAppointments();
            VacationRequest request = new VacationRequest(0, new DateTime(2022, 11, 20), new DateTime(2022, 11, 25), "I need to take some rest", false, "DOC0");

            bool available = doctor.IsAvailable(request.Start, request.End);

            available.ShouldBe(true);
        }

        [Fact]
        public void Cannot_create_non_urgent()
        {
            Doctor doctor = CreateDoctorWithAppointments();
            VacationRequest request = new VacationRequest(0, new DateTime(2022, 11, 16), new DateTime(2022, 11, 25), "I need to take some rest", false, "DOC0");

            bool available = doctor.IsAvailable(request.Start, request.End);

            available.ShouldBe(false);
        }


        private Doctor CreateDoctorWithAppointments()
        {
            List<Appointment> doctorAppointments = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP0", "DOC0", "PAT0", new DateTime(2022, 11, 15), 0));
            doctorAppointments.Add(new Appointment("APP1", "DOC0", "PAT0", new DateTime(2022, 11, 18), 0));
            doctorAppointments.Add(new Appointment("APP2", "DOC0", "PAT0", new DateTime(2022, 11, 26), 0));


            Doctor testDoctor = new Doctor("DOC0", "Doktor", "Doktoric", "nekimail@gmail.com", 0, new Room(), 8, 16, doctorAppointments);
            


            return testDoctor;        
        }
    }
}
