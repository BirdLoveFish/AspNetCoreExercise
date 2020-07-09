using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptionsExercise.Options;

namespace OptionsExercise.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        private readonly IOptions<PeopleOptions> _options;
        private readonly IOptionsSnapshot<PeopleOptions> _optionsSnapshot;
        private readonly IOptionsMonitor<PeopleOptions> _optionsMonitor;

        private readonly StudentOptions _studentOptions1;
        private readonly StudentOptions _studentOptions2;

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration,
            IOptions<PeopleOptions> options,
            IOptionsSnapshot<PeopleOptions> optionsSnapshot,
            IOptionsMonitor<PeopleOptions> optionsMonitor,
            IOptionsSnapshot<StudentOptions> studentSnapshot)
        {
            _logger = logger;
            _configuration = configuration;
            _options = options;
            _optionsSnapshot = optionsSnapshot;
            _optionsMonitor = optionsMonitor;
            _studentOptions1 = studentSnapshot.Get(StudentOptions.Student1);
            _studentOptions2 = studentSnapshot.Get(StudentOptions.Student2);
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            //每次这样读取是很不方便的
            //PeopleOptions people = _configuration.GetSection("People").Get<PeopleOptions>();

            //不能随文件内容的改变而改变
            PeopleOptions people = _options.Value;

            //可以随文件的改变而自行改变
            PeopleOptions people1 = _optionsSnapshot.Value;

            PeopleOptions people2 = _optionsMonitor.CurrentValue;

            return Ok(new { people, people1, people2 });
        }

        [HttpGet("named")]
        public IActionResult Named()
        {
            return Ok(new { _studentOptions1, _studentOptions2 });
        }
    }
}
