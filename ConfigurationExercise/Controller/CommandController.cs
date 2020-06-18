using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationExercise.Controller
{
    public class CommandController: ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CommandController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            //CommandKey=command
            //var result = _configuration["CommandKey"];

            //CommandKey:Son=command-son
            //var result = _configuration["CommandKey:Son"];

            // /CommandKey=equal   结果为equal
            //var result = _configuration["CommandKey"];

            // /CommandKey =equal  结果为=equal
            var result = _configuration["CommandKey"];

            //还可以用 / 和 --

            return Ok(result);
        }
    }
}
