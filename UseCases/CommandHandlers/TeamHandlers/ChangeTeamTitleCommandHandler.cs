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
    class ChangeTeamTitleCommandHandler : IHandleCommand<ChangeTeamTitleCommand>
    {

        readonly ITeamRepository teamRepository;
        public ChangeTeamTitleCommandHandler(ITeamRepository teamRepository)
       => this.teamRepository = teamRepository;

        public Task Handle(ChangeTeamTitleCommand command)
        {
            var team = teamRepository.Find(command.Id);
            if (team == null)
                throw new Exception("Team does not found!!!");
            else if (teamRepository.IsExist(command.Title))
                throw new Exception("Title is already exist!!!");
            else
            {
                team.Title = command.Title;
                teamRepository.ChangeTeamTitle(team);
            }
            

           return Task.CompletedTask;
        }
    }
}
