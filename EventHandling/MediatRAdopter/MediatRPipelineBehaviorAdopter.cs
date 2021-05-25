using EventHandling.Abstractions;
using MediatR;
using MediatRAdopter.EventHandling;
using System.Threading;
using System.Threading.Tasks;

namespace EventHandling.MediatRAdopter
{
    public class MediatRPipelineBehaviorAdopter<TEvent> : IPipelineBehavior<MediatREventEnvelope<TEvent>, Unit>
         where TEvent : AnEvent
    {
        readonly IEventPipelineBehavior<TEvent> _EventPipelineBehavior;
        public MediatRPipelineBehaviorAdopter(IEventPipelineBehavior<TEvent> EventPipelineBehavior)
        => _EventPipelineBehavior = EventPipelineBehavior;

        public async Task<Unit> Handle(MediatREventEnvelope<TEvent> request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            await _EventPipelineBehavior.Handle(request.AEvent, cancellationToken, () => next());
            return Unit.Value;
        }
    }
}
