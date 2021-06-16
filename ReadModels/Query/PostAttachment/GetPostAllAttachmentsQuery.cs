using QueryHandling.Abstractions;
using ReadModels.ViewModel.PostAttachment;
using System;

namespace ReadModels.Query.PostAttachment
{
    public record GetPostAllAttachmentsQuery(int PageNumber, int PageSize, Guid PostId) : Query<PagedViewModel<UserPostAttachmentViewModel>>;
}
