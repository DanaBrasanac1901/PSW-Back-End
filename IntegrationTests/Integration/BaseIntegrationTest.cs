using IntegrationAPI;
using IntegrationTests.Setup;
using Xunit;

namespace IntegrationTests.Integration
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