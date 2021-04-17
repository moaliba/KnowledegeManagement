using CommandHandling.Abstractions;
using Commands.TeamCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            teamRepository.Add(new DomainModel.Team() { TeamId = command.TeamId, Title = command.Title });
            return Task.CompletedTask;
        }
    }
}
