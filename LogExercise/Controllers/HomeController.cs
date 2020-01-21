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
            //_logger.LogInformation($"LogInformation");
            //_logger.LogWarning("LogWarning");
            //_logger.LogCritical("LogCritical");
            //_logger.LogError("LogError");
            //_logger.LogTrace("LogTrace");
            //_logger.LogDebug("LogDebug");
            int a = 0;
            int b = 1;
            _logger.LogInformation("{0},{1}", a, b);    //0,1
            _logger.LogInformation("{0},{0}", a, b);    //1,1
            _logger.LogInformation("{1},{1}", a, b);    //1,2
            _logger.LogInformation("{a},{b}", a, b);    //0,1
            _logger.LogInformation("{a},{a}", a, b);    //1,1
            _logger.LogInformation("{b},{b}", a, b);    //1,1
            _logger.LogInformation("{c},{d}", a, b);    //0,1
            return Ok("Home Index");
        }
    }
}
