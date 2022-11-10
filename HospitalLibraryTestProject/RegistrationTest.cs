using HospitalLibrary.Core.Patient;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class RegistrationTest
    {
        private readonly HospitalDbContext context;
        [Fact]
        public void Registration_unvalidated()
        {
            PatientRepository repository = new PatientRepository(context);
            PatientService service = new PatientService(repository);
            service.Register(new Patient("aa", "aa", "aa", bloodType: HospitalLibrary.Core.Enums.BloodType.B, "aa", "aa", true, -1));
            Assert.False(service.GetById(-1).Active);
            service.Delete(service.GetById(-1));
        }
        [Fact]
        public void Registration_Validate()
        {
            PatientRepository repository = new PatientRepository(context);
            PatientService service = new PatientService(repository);
            Patient example = new Patient("aa", "aa", "aa", bloodType: HospitalLibrary.Core.Enums.BloodType.B, "aa", "aa", true, -1);
            service.Register(example);
            service.Activate(example);
            Assert.True(service.GetById(-1).Active);
            service.Delete(service.GetById(-1));
        }
    }
}
