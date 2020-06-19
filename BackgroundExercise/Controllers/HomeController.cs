using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackgroundExercise.Background4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackgroundExercise.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }

    }
}
