using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundExercise.Background4
{
    public class MessageTaskQueue : IMessageTaskQueue
    {
        private ConcurrentQueue<Func<CancellationToken, Task>> _workItems =
             new ConcurrentQueue<Func<CancellationToken, Task>>();
        private SemaphoreSlim _signal = new SemaphoreSlim(0);

        public async Task<Func<CancellationToken, Task>> Dequeue(CancellationToken token)
        {
            await _signal.WaitAsync(token);

            _workItems.TryDequeue(out var task);

            return task;
        }

        public void Enqueue(Func<CancellationToken, Task> task)
        {
            if(task == null)
            {
                throw new ArgumentNullException();
            }

            _workItems.Enqueue(task);
            _signal.Release();
        }
    }
}
