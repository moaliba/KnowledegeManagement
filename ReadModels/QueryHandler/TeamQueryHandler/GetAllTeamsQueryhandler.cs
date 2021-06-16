using QueryHandling.Abstractions;
using ReadModels.Query.Team;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Team;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TeamQueryHandler
{
    public class GetAllTeamsQueryhandler : IHandleQuery<GetAllTeamsQuery, PagedViewModel<TeamViewModel>>
    {
        readonly IReadDbContext _ReadContext;

        public GetAllTeamsQueryhandler(IReadDbContext _ReadContext)
        {
            this._ReadContext = _ReadContext;
        }

        public  Task<PagedViewModel<TeamViewModel>> Handle(GetAllTeamsQuery query)
        {

            var TotalItems = _ReadContext.TeamViewModels
            .Where(t => t.Title.Contains(query.Title ?? string.Empty));
           
            switch (query.SortOrder)
            {
                case "title":
                    TotalItems = TotalItems.OrderBy(t => t.Title);
                    break;
                case "title_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.Title);
                    break;
                default:
                    break;
            }

            var totalRecords = TotalItems.Count();
            var result = PagingUtility.Paginate(query.PageNumber, query.PageSize, TotalItems);
            return Task.FromResult(result);
        }


    }
}
