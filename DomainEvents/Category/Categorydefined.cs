using EventHandling.Abstractions;
using System;

namespace DomainEvents.Category
{
    public record Categorydefined(Guid id, string title): AnEvent(id);
}