using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SecondApi.Controllers
{
    [ApiController]
    [Route("")]
    public class SecondApiController : ControllerBase
    {
        public SecondApiController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Hello from Second Api!");
        }
    }
}
