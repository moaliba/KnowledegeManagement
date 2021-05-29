using QueryHandling.Abstractions;
using ReadModels.Query.Team;
using ReadModels.ViewModel.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TeamQueryHandler
{
    public class GetTeamQueryHandler : IHandleQuery<GetTeamQuery, TeamViewModel>
    {
        readonly IReadDbContext _dbcontext;
        public GetTeamQueryHandler(IReadDbContext _dbcontext)
        {
            this._dbcontext = _dbcontext;
        }
        public Task<TeamViewModel> Handle(GetTeamQuery query)
        {
            TeamViewModel team = _dbcontext.TeamViewModels.Find(query.TeamId);
            if (team != null)
                return Task.FromResult(team);
            throw new Exception("Team is not found!!!");

        }
    }
}
