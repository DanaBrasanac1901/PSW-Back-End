using HospitalLibrary.Core.Patient;
using System;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class RegisterUnitTests
    {
        [Fact]
        public void Check_parameters()
        {
            PatientService service = new PatientService();
            Patient[] patients = new Patient[]
            {
                new Patient(1, "name", "email1", "password", HospitalLibrary.Core.Enums.BloodType.A, "", "0", true),
                new Patient(1, "879247", "email1", "password", HospitalLibrary.Core.Enums.BloodType.A, "", "1", true),
                new Patient(1, "name", "email2", "password", HospitalLibrary.Core.Enums.BloodType.A, "", "", true),
                new Patient(1, "name", "email3", "password", HospitalLibrary.Core.Enums.BloodType.A, "", "2", true)

            };

            foreach(Patient patient in patients)
            {
                Assert.True(service.CheckRegisterValidity(patient));
            }
            

        }
    }
}
