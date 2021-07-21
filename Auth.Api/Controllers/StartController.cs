using Auth.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class StartController : ControllerBase
    {
        public StartController() { }

        [HttpGet]
        [AuthorizeFilter]
        public IActionResult StartTest()
        {
            return Ok("Api is working.");
        }
    }
}
