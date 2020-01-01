using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogExercise.Controllers
{
    public class HomeController: ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var result = new { name = "zhang" };
            _logger.LogInformation(5,$"LogInformation{result}");
            _logger.LogWarning(6,"LogWarning");
            _logger.LogCritical("LogCritical");
            _logger.LogError("LogError");
            _logger.LogTrace("LogTrace");
            _logger.LogDebug("LogDebug");
            return Ok("Home Index");
        }
    }
}
