using HttpClientExercise.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExercise.Controller
{
    public class HomeController: ControllerBase
    {

        public IActionResult Index()
        {
            return Ok("Home Index");
        }


    }
}
