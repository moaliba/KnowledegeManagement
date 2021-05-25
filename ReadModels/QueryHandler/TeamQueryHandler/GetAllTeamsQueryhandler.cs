using Microsoft.EntityFrameworkCore;
using QueryHandling.Abstractions;
using ReadModels.Query.Team;
using ReadModels.ViewModel.Team;
using System.Collections.Generic;
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
            ///Task.Run(() =>----);
            ///return Task.CompletedTask; when we do not have result.
            //IEnumerable<TeamViewModel> result = await Task.FromResult(_ReadContext.Teams.Select(c => new TeamViewModel()
            //{
            //    Id = c.TeamId,
            //    Title = c.Title
            //})
            //.Where(t=>t.Title.Contains(query.Title ?? string.Empty))
            //.Skip((query.PageNumber - 1) * query.PageSize)
            //.Take(query.PageSize)
            //.AsEnumerable());


            var result = _ReadContext.Teams.Select(c => new TeamViewModel()
            {
                Id = c.TeamId,
                Title = c.Title
            })
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

            

            var totalRecords = await _ReadContext.Teams.Where(t => t.Title.Contains(query.Title ?? string.Empty)).CountAsync();

            //DbSet<DomainModel.Team> teams = _ReadContext.Team;
            //var result = _ReadContext.Team.Select(c => new TeamViewModel()
            //{
            //    TeamId = c.TeamId,
            //    Title = c.Title
            //}).AsEnumerable();

            var teamresult = new TeamViewModelList() { TeamViewModels = result.AsEnumerable() , TotalCount=totalRecords };
            return teamresult;
        }


    }
}
