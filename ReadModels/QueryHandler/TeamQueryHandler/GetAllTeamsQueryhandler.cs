using QueryHandling.Abstractions;
using QueryHandling.MediatRAdopter;
using ReadModels.Query.Team;
using ReadModels.ViewModel.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TeamQueryHandler
{
    public class GetAllTeamsQueryhandler : IHandleQuery<GetAllTeamsQuery, IEnumerable<TeamViewModel>>
    {
        readonly IReadDbContext _ReadContext;

        public GetAllTeamsQueryhandler(IReadDbContext _ReadContext)
        {
            this._ReadContext = _ReadContext;
        }

        public async Task<IEnumerable<TeamViewModel>> Handle(GetAllTeamsQuery query)
        {
            var TeamList = _ReadContext.Teams.Select(c => new TeamViewModel()
            {
                TeamId = c.TeamId,
                Title = c.Title
            }).AsEnumerable();
            return TeamList;
        }

        //Task<List<TeamViewModel>> IHandleQuery<GetAllTeamsQuery, List<TeamViewModel>>.Handle(GetAllTeamsQuery query)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
