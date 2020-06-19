using BackgroundExercise.Background5;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundExercise.Controllers
{
    public class StringController : ControllerBase
    {
        private readonly ILogger<StringController> _logger;
        private readonly IMessageStringQueue _messageStringQueue;

        public StringController(
            ILogger<StringController> logger,
            IMessageStringQueue messageStringQueue)
        {
            _logger = logger;
            _messageStringQueue = messageStringQueue;
        }

        public IActionResult Index(string s)
        {
            _messageStringQueue.Enqueue(s);
            return Ok();
        }
    }
}
