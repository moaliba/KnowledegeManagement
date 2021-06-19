using QueryHandling.Abstractions;
using ReadModels.Query.Category;
using ReadModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.Category
{
    public class UserGetCategoryListQueryHandler : IHandleQuery<UserGetCategoryListQuery, PagedViewModel<CategoryViewModel>>
    {
        private readonly IReadDbContext dbContext;
        public UserGetCategoryListQueryHandler(IReadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<PagedViewModel<CategoryViewModel>> Handle(UserGetCategoryListQuery query)
        {
            var TotalItems = dbContext.CategoryViewModels
            .Where(t => t.Title.StartsWith(query.CategoryTitle ?? string.Empty) && t.IsActive == true);

            switch (query.SortOrder)
            {
                case "title":
                    TotalItems = TotalItems.OrderBy(t => t.Title);
                    break;
                case "title_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.Title);
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
