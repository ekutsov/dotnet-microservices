using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FourthApi.Controllers
{
    [ApiController]
    [Route("")]
    public class FourthApiController : ControllerBase
    {
        public FourthApiController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Hello from Fourth Api!");
        }
    }
}
