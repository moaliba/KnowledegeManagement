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
        
        public  Task<TagViewModelList> Handle(GetAllTagsQuery query)
        {
            var TotalItems = dbContext.TagViewModels
            .Where(t => t.Title.Contains(query.Title ?? string.Empty) && t.IsActive == true && (query.CategoryId ==null || t.CategoryId == query.CategoryId )); //
            //.Skip((query.PageNumber - 1) * query.PageSize)
            //.Take(query.PageSize);

            switch (query.SortOrder)
            {
                case "Title":
                    TotalItems = TotalItems.OrderBy(t => t.Title);
                    break;
                case "Title_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.Title);
                    break;
                case "Category":
                    TotalItems = TotalItems.OrderBy(t => t.CategoryId);
                    break;
                case "Category_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.CategoryId);
                    break;
                default:
                    break;
            }

            var totalRecords = TotalItems.Count();

           // var totalRecords = await dbContext.TagViewModels.CountAsync(t => t.Title.Contains(query.Title ?? string.Empty) && t.IsActive == true && t.CategoryId == query.CategoryId);

            var result=TotalItems
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);

            var tagResult = new TagViewModelList() { TagViewModels = result.AsEnumerable(), TotalCount = totalRecords };
            return Task.FromResult(tagResult);

        }
    }
}
