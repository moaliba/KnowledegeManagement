using QueryHandling.Abstractions;
using ReadModels.Query.Tag;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Tag;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TagQueryHandler
{
    public class GetAllTagsQueryHandler : IHandleQuery<GetAllTagsQuery, PagedViewModel<TagViewModel>>
    {
        readonly IReadDbContext dbContext;

        public GetAllTagsQueryHandler(IReadDbContext dbContext)
        => this.dbContext = dbContext;
        
        public  Task<PagedViewModel<TagViewModel>> Handle(GetAllTagsQuery query)
        {
            var TotalItems = dbContext.TagViewModels
            .Where(t => t.Title.Contains(query.Title ?? string.Empty)  && (query.CategoryId ==null || t.CategoryId == query.CategoryId )); 

            switch (query.SortOrder)
            {
                case "title":
                    TotalItems = TotalItems.OrderBy(t => t.Title);
                    break;
                case "title_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.Title);
                    break;
                case "category":
                    TotalItems = TotalItems.OrderBy(t => t.CategoryName);
                    break;
                case "category_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.CategoryName);
                    break;
                default:
                    TotalItems = TotalItems.OrderBy(t => t.InsertDate);
                    break;
            }

            var totalRecords = TotalItems.Count();

                var result = PagingUtility.Paginate(query.PageNumber, query.PageSize, TotalItems);
                return Task.FromResult(result);
           


            // var totalRecords = await dbContext.TagViewModels.CountAsync(t => t.Title.Contains(query.Title ?? string.Empty) && t.IsActive == true && t.CategoryId == query.CategoryId);

            //var result=TotalItems
            //    .Skip((query.PageNumber - 1) * query.PageSize)
            //    .Take(query.PageSize);
            // var PageCounter = new PageCounter(query.PageNumber, query.PageSize, totalRecords);



            // var result = new PagedViewModel<TagViewModel>(PageCounter, TotalItems);

            //   var tagResult = new TagViewModelList() { TagViewModels = result.ItemsInThePage.AsEnumerable(), TotalCount = totalRecords };

        }


    }
}
