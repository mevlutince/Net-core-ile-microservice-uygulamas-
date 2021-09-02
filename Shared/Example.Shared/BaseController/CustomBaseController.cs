using System;
using System.Collections.Generic;
using System.Text;
using Example.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Example.Shared.BaseController
{

    public class CustomBaseController : ControllerBase
    { 
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
