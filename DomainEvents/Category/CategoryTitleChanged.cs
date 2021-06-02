using EventHandling.Abstractions;
using System;

namespace DomainEvents.Category
{
    public record CategoryTitleChanged(Guid CategoryId, string CategoryTitle): AnEvent(CategoryId);
}
