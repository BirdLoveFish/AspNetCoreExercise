using FilterExercise.ActionFilters;
using FilterExercise.ResultFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExercise.Controllers
{
    //[MyResultFilter("str", 0)]
    public class HomeController: ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[MyResultFilter("str", 0)]
        public IActionResult Index()
        {
            return Ok("Hello Index");
        }

        public class Person
        {
            [Required]
            public string name { get; set; }
            public int age { get; set; }
        }

        [MyActionFilter]
        public IActionResult Para([FromBody]Person person)
        {
            return Ok(person);
        }

        [ServiceFilter(typeof(MyActionServiceFilter))]
        public IActionResult Service()
        {
            return Ok("Home Service");
        }

        [TypeFilter(typeof(MyActionTypeFilter), 
            Arguments= new object[] { "zhang" })]
        public IActionResult Type()
        {
            return Ok("Home Type");
        }

        public IActionResult Auth()
        {
            return Ok("Home Auth");
        }
    }
}
