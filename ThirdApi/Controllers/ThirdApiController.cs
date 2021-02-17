using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ThirdApi.Controllers
{
    [ApiController]
    [Route("")]
    public class ThirdApiController : ControllerBase
    {
        public ThirdApiController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Hello from Third Api!");
        }
    }
}
