using EventHandling.Abstractions;
using MediatR;
using System.Threading.Tasks;

namespace MediatRAdopter.EventHandling
{
    public class MediatREventBusAdopter : IEventBus
    {
        readonly IMediator mediator;

        public MediatREventBusAdopter(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Publish<TEvent>(TEvent Event) where TEvent : AnEvent
        {
            await mediator.Publish(new MediatREventEnvelope<TEvent>(Event));
        }
    }
}