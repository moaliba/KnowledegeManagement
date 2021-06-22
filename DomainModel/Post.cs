using DomainEvents.Post;
using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class Post : AggregateRoot
    {
        public string PostTitle { get; private set; }

        public Guid CategoryId { get; private set; }

        public Guid UserId { get; private set; }

        public List<PostAttachment> AttachmentList { get; set; }

        Post(Guid Id, string PostTitle, string PostContent, Guid CategoryId, Guid UserId, string Tags) : base(Id)
        {
            RecordThat(new PostCreated(Id, PostTitle, PostContent, CategoryId, UserId, Tags));
        }

        public static Post DefinePost(Guid Id, string PostTitle, string PostContent, Guid CategoryId, Guid UserId, string Tags)
            => new(Id, PostTitle, PostContent, CategoryId, UserId, Tags);

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
    }
}
