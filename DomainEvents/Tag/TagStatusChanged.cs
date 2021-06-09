using EventHandling.Abstractions;
using System;


namespace DomainEvents.Tag
{
    public record TagStatusChanged(Guid Id,bool IsActive) : AnEvent(Id);
    
}
