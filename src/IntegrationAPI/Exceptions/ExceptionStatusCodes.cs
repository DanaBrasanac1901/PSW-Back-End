using System;
using System.Collections.Generic;
using System.Net;

namespace IntegrationAPI.Exceptions
{
    public static class ExceptionStatusCodes
    {
        private static Dictionary<Type, HttpStatusCode> exceptionStatusCode = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(BloodBankArgumentException), HttpStatusCode.BadRequest},
            {typeof(BloodBankNotFoundException), HttpStatusCode.NotFound}
         };

        public static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            bool exceptionFound = exceptionStatusCode.TryGetValue(exception.GetType(), out var statusCode);
            return exceptionFound? statusCode : HttpStatusCode.InternalServerError;
        }
        
}
}