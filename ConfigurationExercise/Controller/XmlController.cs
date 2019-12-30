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
            //var result = _configuration.AsEnumerable();

            //var result = _configuration["xmlSection3:age"];
            //return Ok(result.Split(','));

            //var result = _configuration["xmlSection4:age:key0"];

            //var result = _configuration.GetSection("xmlSection4:age").GetChildren();

            var result = _configuration["xmlSection5:name:color"];

            return Ok(result);
        }
    }
}
