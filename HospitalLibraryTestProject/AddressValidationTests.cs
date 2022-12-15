using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class AddressValidationTests
    {
        [Fact]
        public void Street_contains_number()
        {
            RegisterDTO testPatient = new RegisterDTO { Email = "neki mejl", Password = "pass", Name = "name", Surname = "surname", Address = "Fut3!ska 62 Novi Sad", Jmbg = "141561", Age = 13, Allergies = new string[] { "grinje", "vazduh" }, BloodType = "B", DoctorId = "424", Gender = "Female" };

            Assert.Throws<ArgumentException>(() => new Patient(testPatient));
        }

        [Fact]
        public void Street_number_doesnt_contain_number()
        {
            RegisterDTO testPatient = new RegisterDTO { Email = "neki mejl", Password = "pass", Name = "name", Surname = "surname", Address = "Futoska bl Novi Sad", Jmbg = "141561", Age = 13, Allergies = new string[] { "grinje", "vazduh" }, BloodType = "B", DoctorId = "424", Gender = "Female" };

            Assert.Throws<ArgumentException>(() => new Patient(testPatient));
        }

        [Fact]
        public void Empty_adress()
        {
            RegisterDTO testPatient = new RegisterDTO { Email = "neki mejl", Password = "pass", Name = "name", Surname = "surname", Address = "  ", Jmbg = "141561", Age = 13, Allergies = new string[] { "grinje", "vazduh" }, BloodType = "B", DoctorId = "424", Gender = "Female" };

            Assert.Throws<ArgumentException>(() => new Patient(testPatient));
        }

        [Fact]
        public void Successfull_validation()
        {
            RegisterDTO testPatient = new RegisterDTO { Email = "neki mejl", Password = "pass", Name = "name", Surname = "surname", Address = "Futoska 62 Novi Sad", Jmbg = "141561", Age = 13, Allergies = new string[]{ "grinje", "vazduh" }, BloodType = "B", DoctorId = "424", Gender = "Female" };
            Exception e = Record.Exception(() => new Patient(testPatient));
            Assert.Null(e);

        }

    }
}
