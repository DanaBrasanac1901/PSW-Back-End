using System.Collections.Generic;
using IntegrationAPI.DTO;
using IntegrationAPI.Exceptions.Validation;
using IntegrationLibrary.BloodBank;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Exceptions
{
    public class ExceptionService
    {
        [HttpGet]
        public ActionResult<ResponseContent> GetError()
        {
            
            ResponseContent error = new ResponseContent();
            
            return error;

        }
    }
}