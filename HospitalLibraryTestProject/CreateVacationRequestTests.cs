using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using Shouldly;
using System;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class CreateVacationRequestTests
    {
        [Fact]
        public void Can_create_non_urgent()
        {
            Doctor doctor = new Doctor();
            VacationRequest request = new VacationRequest();

            bool available = doctor.IsAvailable(request.Start, request.End);

            available.ShouldBe(true);
        }

        [Fact]
        public void Cannot_create_non_urgent()
        {
            Doctor doctor = new Doctor();
            VacationRequest request = new VacationRequest();

            bool available = doctor.IsAvailable(request.Start, request.End);

            available.ShouldBe(false);
        }
    }
}
