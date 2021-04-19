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
            if (!teamRepository.IsExist(command.Title))
                teamRepository.Add(new DomainModel.Team() { TeamId = command.TeamId, Title = command.Title });
            else
                throw new Exception("Team is already exist!!!");
            return Task.CompletedTask;
        }
    }
}
