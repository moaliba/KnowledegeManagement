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
        readonly ITeamRepository teamRepository;

        public DefineTeamCommandHandler(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public Task Handle(DefineTeamCommand command)
        {
            if (!teamRepository.IsExist(command.Title))
                teamRepository.Add(new Team(command.TeamId, command.Title));
            else
                throw new Exception("Team is already existed!!!");
            return Task.CompletedTask;
        }
    }
}
