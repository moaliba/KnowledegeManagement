using EventHandling.Abstractions;
using System;

namespace DomainEvents.Group
{
    public record GroupMemberSetAsGroupAdmin(Guid groupId, Guid adminId) : AnEvent(groupId);
}