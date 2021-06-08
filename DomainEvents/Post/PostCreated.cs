using EventHandling.Abstractions;
using System;

namespace DomainEvents.Post
{
    public record PostCreated(Guid PostId, string PostTitle, string PostContent, Guid CategoryId, Guid UserId, string Tags) : AnEvent(PostId);
}
