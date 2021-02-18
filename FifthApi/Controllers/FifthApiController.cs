using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifthApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FifthApi.Controllers
{
    [ApiController]
    [Route("")]
    public class FifthApiController : ControllerBase
    {
        private readonly IFifthApiService _service;
        public FifthApiController(IFifthApiService service)
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
