using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("")]
    public class FirstApiController : ControllerBase
    {
        private readonly IFirstApiService _service;
        public FirstApiController(IFirstApiService service) 
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetResult();
            return new JsonResult(result);
        }
    }
}
