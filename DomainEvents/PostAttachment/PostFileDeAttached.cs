using EventHandling.Abstractions;
using System;

namespace DomainEvents.PostAttachment
{
    public record PostFileDeAttached(Guid PostAttachmentId) : AnEvent(PostAttachmentId);
}
