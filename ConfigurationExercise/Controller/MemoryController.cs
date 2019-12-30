using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationExercise.Controller
{
    public class MemoryController: ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MemoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var result = _configuration.GetSection("memorySection1");
            return Ok(result);
        }
    }
}
