using EventHandling.Abstractions;
using System;


namespace DomainEvents.Tag
{
    public record TagDefined(Guid Id, string Title, Guid? CategoryId,bool IsActive, bool DefinedFormPost) : AnEvent(Id);
}
