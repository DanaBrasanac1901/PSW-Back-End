using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace IntegrationAPI.Exceptions
{
    public class ExceptionMiddleware{

        private readonly RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate next) { this.next = next;}

        public async Task InvokeAsync(HttpContext httpContext){
            
            try {await next(httpContext);}
            catch(Exception ex){
                httpContext.Response.StatusCode = (int)ExceptionStatusCodes.GetExceptionStatusCode(ex);
                await httpContext.Response.WriteAsync(ex.Message);}


        }
    }
    public static class MiddlewareExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }

}