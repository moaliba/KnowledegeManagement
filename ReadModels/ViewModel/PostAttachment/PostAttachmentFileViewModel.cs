using QueryHandling.Abstractions;
using System;

namespace ReadModels.ViewModel.PostAttachment
{
    public class PostAttachmentFileViewModel:IAmAViewModel
    {
        public Guid PostAttachmentId { get; set; }

        public byte[] File { get; set; }
    }
}
