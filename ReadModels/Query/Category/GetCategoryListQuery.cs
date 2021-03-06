using QueryHandling.Abstractions;
using ReadModels.ViewModel;
using System;

namespace ReadModels.Query.Category
{
    public record GetCategoryListQuery(Guid Id, int PageNumber, int PageSize, string CategoryTitle, bool? IsActive, string SortOrder) :
        Query<PagedViewModel<CategoryViewModel>>;
}
