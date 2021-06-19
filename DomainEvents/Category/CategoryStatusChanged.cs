using EventHandling.Abstractions;
using System;

namespace DomainEvents.Category
{
    public record CategoryStatusChanged(Guid CategoryId, bool IsActive) : AnEvent(CategoryId);
}
