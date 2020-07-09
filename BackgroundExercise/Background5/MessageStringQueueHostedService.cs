using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundExercise.Background5
{
    public class MessageStringQueueHostedService : BackgroundService
    {
        private readonly ILogger<MessageStringQueueHostedService> _logger;
        private readonly IMessageStringQueue _messageStringQueue;

        public MessageStringQueueHostedService(
            ILogger<MessageStringQueueHostedService> logger,
            IMessageStringQueue messageStringQueue)
        {
            _logger = logger;
            _messageStringQueue = messageStringQueue;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MessageStringQueueHostedService is start");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            int time = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                var message = await _messageStringQueue.Dequeue(stoppingToken);
                var count = _messageStringQueue.Count();

                //进行筛选
                if (count > 0)
                {
                    // 每当执行10次 强制执行
                    time++;
                    if (time < 10)
                    {
                        continue;
                    }
                    time = 0;
                    //continue;
                }

                await Task.Delay(300);

                _logger.LogInformation($"message = {message}, count = {count}");
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("MessageStringQueueHostedService is end");

            await base.StopAsync(cancellationToken);
        }
    }
}
