using HospitalLibrary.Core.Patient;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class LoginRegisterTests
    {
        [Fact]
        public void Check_email_exists()
        {
            
            PatientService service = new PatientService(CreateStubRepository());
            
            Assert.True(service.DoesEmailExist("email2"));
            Assert.False(service.DoesEmailExist("email10"));
        }


        [Fact]
        public void Check_credential_validity()
        {
            PatientService service = new PatientService(CreateStubRepository());

            Assert.True(service.CredentialsValidity("email1", "password1"));
            Assert.False(service.CredentialsValidity("email1", "password3"));
            Assert.False(service.CredentialsValidity("email150", "password1"));
        }


        private static IPatientRepository CreateStubRepository()
        {
            var stubRepo = new Mock<IPatientRepository>();
            var patients = new List<Patient>()
            {
                new Patient(1, "name", "email1", "password1", HospitalLibrary.Core.Enums.BloodType.A, "", "0", true),
                new Patient(2, "name", "email2", "password2", HospitalLibrary.Core.Enums.BloodType.A, "", "1", true),
                new Patient(3, "name", "email3", "password3", HospitalLibrary.Core.Enums.BloodType.A, "", "", true),
                new Patient(4, "name", "email4", "password4", HospitalLibrary.Core.Enums.BloodType.A, "", "2", true)
            };

            stubRepo.Setup(repo => repo.GetAll()).Returns(patients);

            return stubRepo.Object;
        }
    }
}
