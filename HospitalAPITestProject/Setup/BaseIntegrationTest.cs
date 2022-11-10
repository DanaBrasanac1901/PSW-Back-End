using HospitalAPI;
using Xunit;


namespace HospitalAPITestProject.Setup
{
    public class BaseIntegrationTest : IClassFixture<TestDataBaseFactory<Startup>>
    {
        protected TestDataBaseFactory<Startup> Factory { get; }

        public BaseIntegrationTest(TestDataBaseFactory<Startup> factory)
        {
            Factory = factory;
        }
    }
}
