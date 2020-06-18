using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cancellation.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cancellation.Controllers
{
    [OperationCancelledExceptionFilter()]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);

            return Ok("home get");
        }

        [OperationCancelledExceptionFilter()]
        [HttpGet("get2")]
        public async Task<IActionResult> Get2(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 5; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(1000);
            }

            return Ok("home get");
        }


    }
}
