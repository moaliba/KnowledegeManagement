using Microsoft.EntityFrameworkCore;
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
            .Where(t => t.CategoryTitle.Contains(query.CategoryTitle ?? string.Empty));
            //.Skip((query.PageNumber - 1) * query.PageSize)
            //.Take(query.PageSize);

            switch (query.SortOrder)
            {
                case "Title":
                    TotalItems = TotalItems.OrderBy(t => t.CategoryTitle);
                    break;
                case "Title_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.CategoryTitle);
                    break;
                default:
                    break;
            }

            var totalRecords = TotalItems.Count();
            var result = PagingUtility.Paginate(query.PageNumber, query.PageSize, TotalItems);
            return Task.FromResult(result);

            //  var totalRecords = await dbContext.CategoryViewModels.CountAsync(t => t.CategoryTitle.Contains(query.CategoryTitle ?? string.Empty));

            //var CategoryResult = new CategoryViewModelList() { CategoryViewModels = result.AsEnumerable(), TotalCount = totalRecords };
            //return CategoryResult;
        }

       
    }
}
