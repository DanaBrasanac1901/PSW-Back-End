using HospitalAPI.Controllers;
using HospitalLibrary.Core.Vacation.DTO;
using HospitalLibrary.Core.Vacation;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI;
using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalLibrary.Core.InpatientTreatmentRecord.DTO;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HospitalAPITestProject.Integration
{
    public class InpatientTreatmentTests : BaseIntegrationTest
    {
        private object request;

        public InpatientTreatmentTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static InpatientTreatmentController SetupController(IServiceScope scope)
        {
            return new InpatientTreatmentController(scope.ServiceProvider.GetRequiredService<IInpatientTreatmentRecordService>(), (scope.ServiceProvider.GetRequiredService<IEquipmentService>()));
        }

        private static CreateInpatientTretmentRecordDTO SetUpCreateInpatientTreatmentRecordDTO(IServiceScope scope)
        {
            return new CreateInpatientTretmentRecordDTO(scope.ServiceProvider.GetRequiredService<IInpatientTreatmentRecordService>());
        }


        [Fact]
        public void Create_inpatient_treatment_record()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var record = SetUpCreateInpatientTreatmentRecordDTO(scope);
            var result = ((CreatedAtActionResult)controller.CreateRequest(record))?.Value as InpatientTreatmentRecord;

            Assert.NotNull(result);
        }
    }
}
