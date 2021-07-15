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
        public IActionResult StartTest()
        {
            return Ok("Api is working.");
        }
    }
}
