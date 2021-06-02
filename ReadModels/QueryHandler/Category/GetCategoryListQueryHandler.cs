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
    public class GetCategoryListQueryHandler : IHandleQuery<GetCategoryListQuery, CategoryViewModelList>
    {
        private readonly IReadDbContext dbContext;

        public GetCategoryListQueryHandler(IReadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CategoryViewModelList> Handle(GetCategoryListQuery query)
        {
            var result = dbContext.CategoryViewModels
            .Where(t => t.CategoryTitle.Contains(query.CategoryTitle ?? string.Empty))
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize);

            switch (query.SortOrder)
            {
                case "CategoryTitle":
                    result = result.OrderBy(t => t.CategoryTitle);
                    break;
                case "CategoryTitle_desc":
                    result = result.OrderByDescending(t => t.CategoryTitle);
                    break;
                default:
                    break;
            }

            var totalRecords = await dbContext.CategoryViewModels.Where(t => t.CategoryTitle.Contains(query.CategoryTitle ?? string.Empty)).CountAsync();

            var CategoryResult = new CategoryViewModelList() { CategoryViewModels = result.AsEnumerable(), TotalCount = totalRecords };
            return CategoryResult;
        }
    }
}
