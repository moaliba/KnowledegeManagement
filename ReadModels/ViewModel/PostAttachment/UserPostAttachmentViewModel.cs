using QueryHandling.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadModels.ViewModel.PostAttachment
{
    public class UserPostAttachmentViewModel : IAmAViewModel
    {
        [Key]
        public Guid PostAttachmentId { get; set; }

        public string PostAttachmentTitle { get; set; }

        public string FileName { get; set; }
    }
}
