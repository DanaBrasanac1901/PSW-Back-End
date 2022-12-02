using HospitalAPI;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace HospitalTests.Setup
{
    public class BaseIntegrationTest : IClassFixture<TestDatabaseFactory<Startup>>
    {
        protected TestDatabaseFactory<Startup> Factory { get; }

        public BaseIntegrationTest(TestDatabaseFactory<Startup> factory)
        {
            Factory = factory;
        }
    }
}
