using DomainEvents.PostAttachment;
using EventHandling.Abstractions;
using ReadModels.ViewModel.PostAttachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.Projectors.PostAttachment
{
    public class PostAttachmentListProjector : IHandleEvent<PostFileAttached>
    {
        private readonly IReadDbContext readDbContext;
        public PostAttachmentListProjector(IReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext;
        }

        public Task Handle(PostFileAttached e)
        {
            readDbContext.PostAttachmentViewModels.Add(new PostAttachmentViewModel()
            {
                FileName = e.FileName,
                FilePath = e.FilePath,
                FileSize = e.FileSize,
                FileSystemName = e.FileSystemName,
                FileType = e.FileType,
                PostAttachmentId = e.Id,
                PostAttachmentTitle = e.Title,
                PostId = e.PostId,
                UserId = e.UserId,
                InsertDate = DateTime.Now
            });

            return Task.CompletedTask;
        }
    }
}
