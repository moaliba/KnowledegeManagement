using CommandHandling.Abstractions;
using Commands.TeamCommands;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.RepositoryContracts;

namespace CommandHandlers.TeamHandlers
{
    public class DefineTeamCommandHandler : IHandleCommand<DefineTeamCommand>
    {
        readonly ITeamRepository Teams;

        public DefineTeamCommandHandler(ITeamRepository teamRepository)
        {
            this.Teams = teamRepository;
        }

        public Task Handle(DefineTeamCommand command)
        {
            if (!Teams.DoesExist(command.Title))
                Teams.Add(Team.Create(command.TeamId, command.Title));
            else
                throw new Exception("Team already exists!!!");
            return Task.CompletedTask;
        }
    }
}
