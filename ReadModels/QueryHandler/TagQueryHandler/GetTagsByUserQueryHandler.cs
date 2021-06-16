using QueryHandling.Abstractions;
using ReadModels.Query.Tag;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TagQueryHandler
{
    public class GetTagsByUserQueryHandler : IHandleQuery<GetTagsByUserQuery, PagedViewModel<UserTagViewModel>>
    {
        readonly IReadDbContext dbContext;

        public GetTagsByUserQueryHandler(IReadDbContext dbContext)
        => this.dbContext = dbContext;

        public Task<PagedViewModel<UserTagViewModel>> Handle(GetTagsByUserQuery query)
        {
            var TotalItems = dbContext.TagViewModels
           .Where(t => t.Title.StartsWith(query.Title ?? string.Empty) && (query.CategoryId == null || t.CategoryId == query.CategoryId) && t.IsActive==true)
           .Select(Tag=> new UserTagViewModel { Id=Tag.Id,Title=Tag.Title});


            var totalRecords = TotalItems.Count();
            var result = PagingUtility.Paginate(query.PageNumber, query.PageSize, TotalItems);
            return Task.FromResult(result);
        }

    }
}
