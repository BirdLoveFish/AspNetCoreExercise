using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundExercise.Background5
{
    public interface IMessageStringQueue
    {
        void Enqueue(string messgae);

        int Count();

        Task<string> Dequeue(CancellationToken cancellationToken);
    }
}
