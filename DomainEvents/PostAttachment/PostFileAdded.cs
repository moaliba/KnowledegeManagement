using EventHandling.Abstractions;
using System;

namespace DomainEvents.PostAttachment
{
    public record PostFileAdded(Guid Id, string Title, Guid PostId, Guid UserId, string FileName, string FileType,
        string FileSystemName, long FileSize, string FilePath, byte[] File) : AnEvent(Id);
}
