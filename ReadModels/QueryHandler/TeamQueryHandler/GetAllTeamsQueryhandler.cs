using Microsoft.EntityFrameworkCore;
using QueryHandling.Abstractions;
using ReadModels.Query.Team;
using ReadModels.ViewModel.Team;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TeamQueryHandler
{
    public class GetAllTeamsQueryhandler : IHandleQuery<GetAllTeamsQuery, TeamViewModelList>
    {
        readonly IReadDbContext _ReadContext;

        public GetAllTeamsQueryhandler(IReadDbContext _ReadContext)
        {
            this._ReadContext = _ReadContext;
        }

        public async Task<TeamViewModelList> Handle(GetAllTeamsQuery query)
        {
           
            var result = _ReadContext.TeamViewModels
            .Where(t => t.Title.Contains(query.Title ?? string.Empty))
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize);

            switch (query.SortOrder)
            {
                case "Title":
                    result= result.OrderBy(t => t.Title);
                    break;
                case "Title_desc":
                    result = result.OrderByDescending(t => t.Title);
                    break;
                default:
                    break;
            }

            var totalRecords = await _ReadContext.TeamViewModels.Where(t => t.Title.Contains(query.Title ?? string.Empty)).CountAsync();

            var teamresult = new TeamViewModelList() { TeamViewModels = result.AsEnumerable() , TotalCount=totalRecords };
            return teamresult;
        }


    }
}
