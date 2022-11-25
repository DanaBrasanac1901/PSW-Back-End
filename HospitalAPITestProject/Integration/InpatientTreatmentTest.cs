using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalLibrary.Core.InpatientTreatmentRecord.DTO;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;


namespace HospitalTests.Integration
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
