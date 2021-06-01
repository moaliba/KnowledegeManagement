using CommandHandling.Abstractions;
using Commands.TeamCommands;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.TeamHandlers
{
    class ChangeTeamTitleCommandHandler : IHandleCommand<ChangeTeamTitleCommand>
    {

        readonly ITeamRepository Teams;
        public ChangeTeamTitleCommandHandler(ITeamRepository teamRepository)
       => this.Teams = teamRepository;

        public Task Handle(ChangeTeamTitleCommand command)
        {
            Team team = Teams.Find(command.Id);
            if (team == null)
                throw new Exception("Team is not found!!!");
            else if (Teams.DoesExist(command.Title))
                throw new Exception("Title  already exists!!!");
            else
            {
                team.Rename(command.Title);
                Teams.Update(team);
            }
            

           return Task.CompletedTask;
        }
    }
}
