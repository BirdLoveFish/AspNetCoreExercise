using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    public class HomeController: ControllerBase
    {
        public HomeController()
        {

        }
        public IActionResult Index()
        {
            return Ok("Home Index");
        }
    }
}
