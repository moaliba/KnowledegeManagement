using QueryHandling.Abstractions;
using ReadModels.ViewModel.Tag;
using System;

namespace ReadModels.Query.Tag
{
    public record GetAllTagsQuery( int PageNumber, int PageSize, Guid? CategoryId, string Title, string SortOrder) : Query<PagedViewModel<TagViewModel>>;
    
}
