using DomainEvents.Post;
using DomainEvents.PostAttachment;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DomainModel
{
    public class Post : AggregateRoot
    {
        public string PostTitle { get; private set; }

        public Guid CategoryId { get; private set; }

        public Guid UserId { get; private set; }

        public List<PostAttachment> AttachmentList { get; private set; } = new List<PostAttachment>();

        Post(Guid Id, string PostTitle, string PostContent, Guid CategoryId, Guid UserId, string Tags) : base(Id)
        => RecordThat(new PostCreated(Id, PostTitle, PostContent, CategoryId, UserId, Tags));

        public static Post DefinePost(Guid Id, string PostTitle, string PostContent, Guid CategoryId, Guid UserId, string Tags)
        => new(Id, PostTitle, PostContent, CategoryId, UserId, Tags);

        public void AttachFile(Guid id, string Title, Guid PostId, Guid UserId, string FileName, string FileType,
            long FileSize, string FilePath, byte[] File)
        => RecordThat(new PostFileAttached(id, Title, PostId, UserId, FileName, FileType, string.Empty, FileSize, FilePath, File));

        public void DetachFile(PostAttachment Attachment)
        => RecordThat(new PostFileDeAttached(Attachment.Id));

        public void AddFile(Guid postAttachmentId, string FilePath)
        {
            PostAttachment postAttachment = AttachmentList.FirstOrDefault(c => c.Id == postAttachmentId);
            if (postAttachment != null)
                RecordThat(new PostFileAdded(postAttachmentId, postAttachment.Title, postAttachment.PostId, postAttachment.UserId,
                    postAttachment.FileName, postAttachment.FileType, postAttachment.FileSystemName, postAttachment.FileSize,
                    postAttachment.FilePath, postAttachment.File));
        }

        [Obsolete]
        Post()
        {
        }

        void On(PostCreated e)
        {
            PostTitle = e.PostTitle;
            CategoryId = e.CategoryId;
            UserId = e.UserId;
        }

        void On(PostFileAttached e)
        {
            AttachmentList.Add(PostAttachment.AttachFile(e.Id, e.Title, Id, UserId, e.FileName, e.FileType, e.FileSize, e.FilePath, e.File));
        }

        void On(PostFileDeAttached e)
        {
            PostAttachment postAttachment = AttachmentList.FirstOrDefault(c => c.Id == e.PostAttachmentId);
            if (postAttachment != null)
                AttachmentList.Remove(postAttachment);
        }

        void On(PostFileAdded e)
        {

        }
    }
}
