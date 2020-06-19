using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundExercise.Background4
{
    public class MessageQueueHostedService : BackgroundService
    {
        private readonly ILogger<MessageQueueHostedService> _logger;
        private readonly IMessageTaskQueue _messageTaskQueue;

        public MessageQueueHostedService(ILogger<MessageQueueHostedService> logger,
            IMessageTaskQueue messageTaskQueue)
        {
            _logger = logger;
            _messageTaskQueue = messageTaskQueue;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MessageQueueHostedService is start");

            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var work = await _messageTaskQueue.Dequeue(stoppingToken);

                try
                {
                    await work(stoppingToken);
                }
                catch (Exception)
                {
                    _logger.LogError("error");
                }
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("MessageQueueHostedService is end");

            await base.StopAsync(cancellationToken);
        }
    }
}
