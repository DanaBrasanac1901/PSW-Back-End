using HospitalLibrary.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class PasswordValueObjectTests
    {
        [Fact]
        public void InvalidateLowercase()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "samomala" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));

        }

        [Fact]
        public void InvalidateUppercase()
        {

            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "SAMOVELIKA" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }



        [Fact]
        public void InvalidateNumeric()
        {

            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "123222" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        public void InvalidateSpecial()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "!!!!!!!!!!" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        public void InvalidateLessThan()
        {

            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "<6" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        public void InvalidateUpperAndLower()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "malaiVELIKA" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        public void InvalidateUpperAndSpecial()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "VELIKA!!!!!!" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        public void InvalidateLowerAndSpecial()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "mala!!!!!!" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        public void InvalidateUpperAndNumeric()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "VELIKA3423424" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        public void InvalidateLowerAndNumeric()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "mala3242423" };
            Assert.Throws<ArgumentException>(() => new User(regDTO, 1));
        }

        [Fact]
        public void InvalidateSuccess()
        {
            RegisterDTO regDTO = new RegisterDTO() { Name = "testName", Surname = "testSurname", Email = "test", Password = "mala&VELIKA123" };
            Exception e= Record.Exception(()=> new User(regDTO, 1));
            Assert.Null(e);
        }
    }
}
