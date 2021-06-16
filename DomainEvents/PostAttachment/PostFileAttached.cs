using EventHandling.Abstractions;
using System;

namespace DomainEvents.PostAttachment
{
    public record PostFileAttached(Guid Id, string Title, Guid PostId, Guid UserId, string FileName, string FileType,
        string FileSystemName, long FileSize, string FilePath) : AnEvent(Id);
}