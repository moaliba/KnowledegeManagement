using QueryHandling.Abstractions;
using ReadModels.ViewModel.Post;
using System;

namespace ReadModels.Query.Post
{
    public record GetPostQuery(Guid Id) : Query<PostWithAttachmentViewModel>;
}
