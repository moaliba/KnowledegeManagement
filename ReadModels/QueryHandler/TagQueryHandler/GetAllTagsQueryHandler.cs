using Microsoft.EntityFrameworkCore;
using QueryHandling.Abstractions;
using ReadModels.Query.Tag;
using ReadModels.ViewModel.Tag;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TagQueryHandler
{
    public class GetAllTagsQueryHandler : IHandleQuery<GetAllTagsQuery, TagViewModelList>
    {
        readonly IReadDbContext dbContext;

        public GetAllTagsQueryHandler(IReadDbContext dbContext)
        => this.dbContext = dbContext;
        
        public async Task<TagViewModelList> Handle(GetAllTagsQuery query)
        {
            var result = dbContext.TagViewModels
            .Where(t => t.Title.Contains(query.Title ?? string.Empty) && t.IsActive==true)
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize);

            switch (query.SortOrder)
            {
                case "Title":
                    result = result.OrderBy(t => t.Title);
                    break;
                case "Title_desc":
                    result = result.OrderByDescending(t => t.Title);
                    break;
                default:
                    break;
            }

            var totalRecords = await dbContext.TagViewModels.Where(t => t.Title.Contains(query.Title ?? string.Empty) && t.IsActive == true).CountAsync();

            var tagResult = new TagViewModelList() { TagViewModels = result.AsEnumerable(), TotalCount = totalRecords };
            return tagResult;

        }
    }
}
