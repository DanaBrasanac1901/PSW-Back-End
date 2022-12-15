using HospitalLibrary.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class EmailValueObjectTests
    {
        [Fact]
        private void WrongEmail()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "mala&VELIKA123" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        private void CorrectEmail()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test@gmail.com", Password = "mala&VELIKA123" };
            Exception e = Record.Exception(() => new User(regDTO, 1));
            Assert.Null(e);
        }
    }
}
