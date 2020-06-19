using BackgroundExercise.Background4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundExercise.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMessageTaskQueue _messageTaskQueue;

        public TaskController(ILogger<HomeController> logger,
            IMessageTaskQueue messageTaskQueue)
        {
            _logger = logger;
            _messageTaskQueue = messageTaskQueue;
        }

        public IActionResult Index(string s)
        {
            _messageTaskQueue.Enqueue(async token =>
            {
                if (!token.IsCancellationRequested)
                {
                    await Task.Delay(200);

                    _logger.LogInformation($"message={s}");
                }
            });
            return Ok();
        }
    }
}
