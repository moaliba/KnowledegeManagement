using CommandHandling.Abstractions;
using Commands.TeamCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.TeamHandlers
{
    class DeleteTeamCommandHandler : IHandleCommand<DeleteTeamCommand>
    {
        readonly ITeamRepository Teams;

        public DeleteTeamCommandHandler(ITeamRepository teamRepository)
        => this.Teams = teamRepository;

        public Task Handle(DeleteTeamCommand command)
        {
            var team = Teams.Find(command.Id);
            if (team == null)
                throw new Exception("Team is not found!!!");
            team.Remove();
            Teams.Delete(team);
            return Task.CompletedTask;
        }
    }
}
