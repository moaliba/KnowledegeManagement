using QueryHandling.Abstractions;
using ReadModels.Query.Category;
using ReadModels.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.Category
{
    public class GetCategoryListQueryHandler : IHandleQuery<GetCategoryListQuery, PagedViewModel<CategoryViewModel>>
    {
        private readonly IReadDbContext dbContext;

        public GetCategoryListQueryHandler(IReadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public  Task<PagedViewModel<CategoryViewModel>> Handle(GetCategoryListQuery query)
        {
            var TotalItems = dbContext.CategoryViewModels
            .Where(t => t.CategoryTitle.StartsWith(query.CategoryTitle ?? string.Empty));

            switch (query.SortOrder)
            {
                case "title":
                    TotalItems = TotalItems.OrderBy(t => t.CategoryTitle);
                    break;
                case "title_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.CategoryTitle);
                    break;
                default:
                    TotalItems = TotalItems.OrderBy(t => t.InsertDate);
                    break;
            }

            var totalRecords = TotalItems.Count();
            var result = PagingUtility.Paginate(query.PageNumber, query.PageSize, TotalItems);
            return Task.FromResult(result);

        }

       
    }
}
