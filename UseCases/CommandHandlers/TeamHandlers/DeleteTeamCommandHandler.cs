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
        readonly ITeamRepository teamRepository;

        public DeleteTeamCommandHandler(ITeamRepository teamRepository)
        => this.teamRepository = teamRepository;
       
        public  Task Handle(DeleteTeamCommand command)
        {
            var team = teamRepository.Find(command.Id);
            if (team == null)
                throw new Exception("Team does not found!!!");
            else
                teamRepository.Delete(team);

            return Task.CompletedTask;
        }
    }
}
