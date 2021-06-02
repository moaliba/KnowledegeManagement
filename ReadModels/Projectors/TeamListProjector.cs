using DomainEvents;
using DomainEvents.Team;
using EventHandling.Abstractions;
using ReadModels.ViewModel.Team;
using System;
using System.Threading.Tasks;

namespace ReadModels.Projectors
{
    public class TeamListProjector : IHandleEvent<TeamDefined> , IHandleEvent<TeamTitleChanged> ,IHandleEvent<TeamDeleted>
    {
        private readonly IReadDbContext dbContext;
        public TeamListProjector(IReadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Handle(TeamDefined e)
        {
            dbContext.TeamViewModels.Add(new TeamViewModel
            {
                Id = e.TeamId,
                Title = e.Title
            });
            Console.WriteLine("PROVINCE ADDED PROJECTED!!!!!!!!!!!");
            return Task.CompletedTask;
        }

        public Task Handle(TeamTitleChanged e)
        {
            TeamViewModel team = dbContext.TeamViewModels.Find(e.TeamId);
            if(team == null)
                throw new Exception("Team is not found!!!");
            team.Title = e.Title;
            return Task.CompletedTask;
        }

        public Task Handle(TeamDeleted e)
        {
            TeamViewModel team = dbContext.TeamViewModels.Find(e.TeamId);
            if (team == null)
                throw new Exception("Team is not found!!!");
            dbContext.TeamViewModels.Remove(team);
            return Task.CompletedTask;
        }
    }
}
