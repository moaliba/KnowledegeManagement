using QueryHandling.Abstractions;
using ReadModels.ViewModel.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.Query.Tag
{
    public record GetAllTagsQuery( int PageNumber, int PageSize, Guid? CategoryId, string Title, string SortOrder) : Query<PagedViewModel<TagViewModel>>;
    
}
