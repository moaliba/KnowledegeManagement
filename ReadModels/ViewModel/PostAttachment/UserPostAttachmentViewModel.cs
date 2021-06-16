using QueryHandling.Abstractions;
using System;

namespace ReadModels.ViewModel.PostAttachment
{
    public class UserPostAttachmentViewModel : IAmAViewModel
    {
        public Guid PostAttachmentId { get; set; }

        public string PostAttachmentTitle { get; set; }

        public string FileName { get; set; }
    }
}
