using QueryHandling.Abstractions;
using ReadModels.ViewModel.PostAttachment;
using System.Collections.Generic;

namespace ReadModels.ViewModel.Post
{
    public class PostWithAttachmentViewModel : IAmAViewModel
    {
        public PostViewModel PostViewModel { get; set; }

        public List<PostAttachmentViewModel> FileAttachments { get; set; }
    }
}
