using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FifthApi.Controllers
{
    [ApiController]
    [Route("")]
    public class FifthApiController : ControllerBase
    {
        public FifthApiController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Hello from Fifth Api!");
        }
    }
}
