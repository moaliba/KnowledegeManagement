using EventHandling.Abstractions;
using MediatR;
using System;
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
            var e = Activator.CreateInstance(typeof(MediatREventEnvelope<>).MakeGenericType(Event.GetType()), new[] { Event });
            await mediator.Publish(e);
            //await mediator.Publish(new MediatREventEnvelope<TEvent>(Event));
        }
    }
}