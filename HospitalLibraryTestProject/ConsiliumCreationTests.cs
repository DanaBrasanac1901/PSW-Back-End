using HospitalLibrary.Core.Consiliums.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using HospitalLibrary.Core;
using HospitalLibrary.Core.Doctor;
using Moq;

namespace HospitalLibraryTestProject
{
    public class ConsiliumCreationTests
    {
        [Fact]
        public void Has_available_appointments()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            ConsiliumAppointmentInfoDTO consiliumAppointmentInfo = new ConsiliumAppointmentInfoDTO(new DateTimeRange(new DateTime(2022, 12, 5), new DateTime(2022, 12, 10)), 45, "DOC1,DOC2,DOC3"); 

            List<ConsiliumAppointmentInfoDTO> potentialConsiliumAppointments = doctorService.GetPotentialAppointmentTimes(consiliumAppointmentInfo);

            Assert.NotEmpty(potentialConsiliumAppointments);
        }
        [Fact]
        public void Has_no_available_appointments()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            ConsiliumAppointmentInfoDTO consiliumAppointmentInfo = new ConsiliumAppointmentInfoDTO(new DateTimeRange(new DateTime(2022, 12, 5), new DateTime(2022, 12, 10)), 45, "DOC1,DOC2,DOC3");

            List<ConsiliumAppointmentInfoDTO> potentialConsiliumAppointments = doctorService.GetPotentialAppointmentTimes(consiliumAppointmentInfo);

            Assert.Empty(potentialConsiliumAppointments);
        }

        private IDoctorRepository CreateDoctorRepository()
        {
            var stubRepo = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();

            //create instances of doctors with appointments, add to list doctors

            stubRepo.Setup(m => m.GetAll()).Returns(doctors);

            return stubRepo.Object;
        }
    }
}
