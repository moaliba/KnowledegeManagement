using QueryHandling.Abstractions;
using ReadModels.ViewModel.Tag;
using System;

namespace ReadModels.Query.Tag
{
    public record  GetTagQuery(Guid Id) : Query<TagViewModel>;
    
}
