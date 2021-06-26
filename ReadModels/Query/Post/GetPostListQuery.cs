using QueryHandling.Abstractions;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Post;
using System;

namespace ReadModels.Query.Post
{
    public record GetPostListQuery(int PageNumber, int PageSize, Guid? CategoryId, string PostTitle,
                                    string Tags, string SortOrder) : Query<PagedViewModel<PostViewModel>>;
}
