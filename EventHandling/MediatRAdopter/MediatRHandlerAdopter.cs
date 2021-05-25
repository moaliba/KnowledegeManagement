using EventHandling.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRAdopter.EventHandling
{
    public class MediatRHandlerAdopter<TEvent> : INotificationHandler<MediatREventEnvelope<TEvent>> where TEvent : AnEvent
    {
        readonly IHandleEvent<TEvent> _ourHandler;
        public MediatRHandlerAdopter(IHandleEvent<TEvent> ourHandler)
        {
            _ourHandler = ourHandler;
        }

        public async Task Handle(MediatREventEnvelope<TEvent> Event, CancellationToken cancellationToken)
        {
            await _ourHandler.Handle(Event.AEvent);
            
        }


    }
}