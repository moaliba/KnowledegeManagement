using QueryHandling.Abstractions;
using ReadModels.ViewModel;
using System;

namespace ReadModels.Query.Category
{
    public record UserGetCategoryListQuery(Guid Id, int PageNumber, int PageSize, string CategoryTitle, string SortOrder) :
        Query<PagedViewModel<CategoryViewModel>>;
}
