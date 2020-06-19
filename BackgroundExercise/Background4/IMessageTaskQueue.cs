using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundExercise.Background4
{
    public interface IMessageTaskQueue
    {
        void Enqueue(Func<CancellationToken, Task> task);

        Task<Func<CancellationToken, Task>> Dequeue(CancellationToken token);
    }
}
