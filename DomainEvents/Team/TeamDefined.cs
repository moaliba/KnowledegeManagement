using System;
using EventHandling.Abstractions;

namespace DomainEvents
{
    public record  TeamDefined(Guid TeamId,string Title) : AnEvent(TeamId);
}
