using QueryHandling.Abstractions;
using ReadModels.Query.Category;
using ReadModels.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.Category
{
    public class GetCategoryQueryHandler : IHandleQuery<GetCategoryQuery, CategoryViewModel>
    {
        private readonly IReadDbContext dbContext;
        public GetCategoryQueryHandler(IReadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<CategoryViewModel> Handle(GetCategoryQuery query)
        {
            CategoryViewModel category = dbContext.CategoryViewModels.FirstOrDefault(c => c.Id == query.CategoryId);
            if (category != null)
                return Task.FromResult(category);
            throw new Exception("team does not exist.");
        }
    }
}
