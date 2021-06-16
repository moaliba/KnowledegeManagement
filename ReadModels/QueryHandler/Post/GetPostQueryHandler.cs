using QueryHandling.Abstractions;
using ReadModels.Query.Post;
using ReadModels.ViewModel.Post;
using System.Linq;
using System.Threading.Tasks;
using LinqKit;
using ReadModels.ViewModel;

namespace ReadModels.QueryHandler.Post
{
    public class GetPostQueryHandler : IHandleQuery<GetPostQuery, PagedViewModel<PostViewModel>>
    {
        private readonly IReadDbContext readDbContext;
        public GetPostQueryHandler(IReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext;
        }

        Task<PagedViewModel<PostViewModel>> IHandleQuery<GetPostQuery, PagedViewModel<PostViewModel>>.Handle(GetPostQuery query)
        {
            string[] Tags = query.Tags.Split(new char[',']);
            var TotalItems = readDbContext.PostViewModels.Where(c => (c.PostContent.Contains(query.PostTitle) 
                        && c.CategoryID == query.CategoryId));

            var pr = PredicateBuilder.False<PostViewModel>();
            foreach (string item in Tags)
            {
                pr = pr.Or(x => x.Tags.Contains(item));
            }
            TotalItems.AsExpandable().Where(pr);

            switch (query.SortOrder)
            {
                case "PostTitle":
                    TotalItems = TotalItems.OrderBy(t => t.PostTitle);
                    break;
                case "PostTitle_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.PostTitle);
                    break;
                default:
                    //  TotalItems = TotalItems.OrderBy(t => t.Title);
                    break;
            }

            var totalRecords = TotalItems.Count();
            var result = PagingUtility.Paginate(query.PageNumber, query.PageSize, TotalItems);
            return Task.FromResult(result);
        }
    }
}
