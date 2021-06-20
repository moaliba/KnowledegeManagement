using EventHandling.Abstractions;
using System;

namespace DomainEvents.Category
{
    public record CategoryDeleted(Guid CategoryId) : AnEvent(CategoryId);
}
