using QueryHandling.Abstractions;
using ReadModels.ViewModel.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.Query.Tag
{
    public record GetAllTagsQuery(Guid Id, int PageNumber, int PageSize, string Title, string SortOrder) : Query<TagViewModelList>;
    
}
