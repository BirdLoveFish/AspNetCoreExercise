using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationExercise.Controller
{
    public class XmlController: ControllerBase
    {
        private readonly IConfiguration _configuration;

        public XmlController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
