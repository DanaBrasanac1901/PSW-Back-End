using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Feedback;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAPITestProject.Selenium.PublishFeedbackTest
{
    public class PublishFeedbackTest: BaseIntegrationTest
    {

        public PublishFeedbackTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static FeedbackController SetupController(IServiceScope scope)
        {
            return new FeedbackController(scope.ServiceProvider.GetRequiredService<IFeedbackService>());

        }

        [Fact]
        public void PublishesFeedback()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
           
          
        }

    }
}
