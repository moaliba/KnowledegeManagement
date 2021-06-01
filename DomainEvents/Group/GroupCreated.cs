using EventHandling.Abstractions;
using System;

namespace DomainEvents.Group
{
    public record GroupCreated(Guid Id, string Title) : AnEvent(Id);
}