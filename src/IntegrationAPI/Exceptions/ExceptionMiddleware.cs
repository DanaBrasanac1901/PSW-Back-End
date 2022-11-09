using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace IntegrationAPI.Exceptions
{
    public class ExceptionMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BloodBankArgumentException error)
            {
                var response = context.Response;
                //Set response ContentType
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                var responseContent = new ResponseContent()
                {
                    Error = error.Message
                };
                //Using Newtonsoft.Json to convert object to json string
                var jsonResult = JsonConvert.SerializeObject(responseContent);
                await context.Response.WriteAsync(jsonResult);
            }

        }

    }
}