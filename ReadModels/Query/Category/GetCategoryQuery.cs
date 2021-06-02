using QueryHandling.Abstractions;
using ReadModels.ViewModel;
using System;

namespace ReadModels.Query.Category
{
    public record GetCategoryQuery(Guid CategoryId) : Query<CategoryViewModel>;
}
