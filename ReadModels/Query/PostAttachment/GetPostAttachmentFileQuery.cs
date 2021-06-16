using QueryHandling.Abstractions;
using ReadModels.ViewModel.PostAttachment;
using System;

namespace ReadModels.Query.PostAttachment
{
    public record GetPostAttachmentFileQuery(Guid PostAttachmentId) : Query<PostAttachmentFileViewModel>;
}
