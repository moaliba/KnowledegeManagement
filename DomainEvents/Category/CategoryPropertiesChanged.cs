using EventHandling.Abstractions;
using System;

namespace DomainEvents.Category
{
    public record CategoryPropertiesChanged(Guid CategoryId, string CategoryTitle, bool IsActive): AnEvent(CategoryId);
}
