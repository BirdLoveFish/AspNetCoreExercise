using ConfigurationExercise.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationExercise.Controller
{
    public class IniController: ControllerBase
    {
        private readonly IConfiguration _configuration;

        public IniController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            //var result = _configuration.AsEnumerable();

            //var result = _configuration["section00"];

            //var result = _configuration["section0:name"];

            //var result = _configuration["section1:sub:name"];

            //var result = _configuration["section2:sub1:name"];

            //var result = _configuration.GetSection("section2").Get<Section2>();

            var result = _configuration.Get<IniArray>();

            return Ok(result);
        }
    
    }
}
