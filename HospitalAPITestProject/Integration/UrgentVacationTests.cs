using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Vacation.DTO;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class UrgentVacationTests : BaseIntegrationTest
    {
        private object request;

        public UrgentVacationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static VacationController SetupController(IServiceScope scope)
        {
            return new VacationController(scope.ServiceProvider.GetRequiredService<IVacationService>());
        }

        private static CreateUrgenVacationDTO SetUpCreateVacationRequestDTO(IServiceScope scope)
        {
            return new CreateUrgenVacationDTO(scope.ServiceProvider.GetRequiredService<IVacationService>());
        }

        [Fact]
        public void Create_urgent_vacation_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            var record = SetUpCreateVacationRequestDTO(scope);
            var result = ((OkObjectResult)controller.CreateUrgentRequest(record))?.Value as string;
            Assert.Equal("Passed",result);
        }

        public class CustomError : IActionResult
        {
            private readonly HttpStatusCode _status;
            private readonly object _errorMessage;

            public CustomError(HttpStatusCode status, object errorMessage)
            {
                _status = status;
                _errorMessage = errorMessage;
            }

            public async Task ExecuteResultAsync(ActionContext context)
            {
                var objectResult = new ObjectResult(new
                {
                    errorMessage = _errorMessage
                })
                {
                    StatusCode = (int)_status,
                };

                context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = (string)_errorMessage;

                await objectResult.ExecuteResultAsync(context);
            }
        }
    }
}
