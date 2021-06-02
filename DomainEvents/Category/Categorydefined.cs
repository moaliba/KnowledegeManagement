using EventHandling.Abstractions;
using System;

namespace DomainEvents.Category
{
    public record Categorydefined(Guid CategoryId, string CategoryTitle): AnEvent(CategoryId);
}