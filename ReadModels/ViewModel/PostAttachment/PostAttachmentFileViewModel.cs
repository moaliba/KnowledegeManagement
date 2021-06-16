using QueryHandling.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadModels.ViewModel.PostAttachment
{
    public class PostAttachmentFileViewModel:IAmAViewModel
    {
        [Key]
        public Guid PostAttachmentId { get; set; }

        public byte[] File { get; set; }
    }
}
