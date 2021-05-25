using EventHandling.Abstractions;
using MediatR;

namespace MediatRAdopter.EventHandling
{
    public class MediatREventEnvelope<TEvent> : INotification where TEvent : AnEvent
    {
        public MediatREventEnvelope(TEvent Event)
        {
            AEvent = Event;
        }
        public TEvent AEvent { get; private set; }
    }
}