using QueryHandling.Abstractions;
using System;

namespace ReadModels.ViewModel.PostAttachment
{
    public class PostAttachmentViewModel : IAmAViewModel
    {
        public Guid PostAttachmentId { get; set; }

        public string PostAttachmentTitle { get; set; }

        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string FileSystemName { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public long FileSize { get; set; }

        public string FilePath { get; set; }

        public DateTime InsertDate { get; set; }
    }
}
