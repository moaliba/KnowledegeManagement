using Xunit;
using FluentAssertions;
using System;
using DomainModel;
using DomainEvents.PostAttachment;

namespace KnowledgeManagement
{
    public class AddNewAttachmentSpec
    {
        [Theory]
        [InlineData("LearninigSQl", "SqlPart1", "mp4", 3370000, "aabba")]
        [InlineData("LearninigC#", "C#Part1", "mp4", 4550000, "aaaaa")]
        public void AddNewAttachment(string Title, string FileName, string FileType, long FileSize, string FilePath)
        {
            Guid id = Guid.NewGuid();
            Guid PostId = Guid.NewGuid();
            Guid UserId = Guid.NewGuid();
            Guid FileSystemName = Guid.NewGuid();
            byte[] File = new byte[] { };
            PostAttachment postAttachment = PostAttachment.AttachFile(id, Title, PostId, UserId, FileName, FileType, FileSize, FilePath, File);
            postAttachment.Events.Should().ContainEquivalentOf(
                    new PostFileAttached(id, Title, PostId, UserId, FileName, FileType, postAttachment.FileSystemName, FileSize, FilePath, File));
        }
    }
}