using QueryHandling.Abstractions;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Tag;
using System;


namespace ReadModels.Query.Tag
{
    public record GetTagsByUserQuery(int PageNumber, int PageSize, Guid? CategoryId, string Title) : Query<PagedViewModel<UserTagViewModel>>;
   
}
