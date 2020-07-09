using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundExercise.Background5
{
    public class MessageStringQueue : IMessageStringQueue
    {
        private ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();
        private SemaphoreSlim _signal = new SemaphoreSlim(0);

        public int Count()
        {
            return _queue.Count();
        }

        public async Task<string> Dequeue(CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);

            _queue.TryDequeue(out string message);

            return message;
        }

        public void Enqueue(string messgae)
        {
            if (messgae == null)
            {
                throw new ArgumentNullException();
            }

            _queue.Enqueue(messgae);
            _signal.Release();
        }
    }
}
