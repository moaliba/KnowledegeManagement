using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventHandling.Abstractions
{

    public interface IEventPipelineBehavior<TEvent>
        where TEvent : AnEvent
    {
        Task Handle(TEvent Event, CancellationToken cancellationToken, Func<Task> next);
    }
}
