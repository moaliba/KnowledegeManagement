using QueryHandling.Abstractions;
using ReadModels.Query.Team;
using ReadModels.ViewModel.Team;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TeamQueryHandler
{
    public class GetAllTeamsQueryhandler : IHandleQuery<GetAllTeamsQuery, TeamViewModelOutPut>
    {
        readonly IReadDbContext _ReadContext;

        public GetAllTeamsQueryhandler(IReadDbContext _ReadContext)
        {
            this._ReadContext = _ReadContext;
        }

        public async Task<TeamViewModelOutPut> Handle(GetAllTeamsQuery query)
        {
            ///Task.Run(() =>----);
            ///return Task.CompletedTask; when we do not have result.
            IEnumerable<TeamViewModel> result = await Task.FromResult(_ReadContext.Teams.Select(c => new TeamViewModel()
            {
                TeamId = c.TeamId,
                Title = c.Title
            }).AsEnumerable());
            
            return new TeamViewModelOutPut() { TeamViewModels = result };
        }
    }
}
