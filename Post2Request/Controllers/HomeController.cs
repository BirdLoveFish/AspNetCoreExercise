using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Post2Request.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Home Get");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Home Post");
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok("Home Patch");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Home Put");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Home Delete");
        }
    }
}
