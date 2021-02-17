using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("")]
    public class FirstApiController : ControllerBase
    {
        public FirstApiController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Hello from First Api!");
        }
    }
}
